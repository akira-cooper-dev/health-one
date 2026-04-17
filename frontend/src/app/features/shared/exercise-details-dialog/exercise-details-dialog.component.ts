import { Component, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ExerciseByIdData, ExerciseService } from '../../../api';
import { map } from 'rxjs/internal/operators/map';
import { Observable } from 'rxjs/internal/Observable';
import { VideoPlayerOptions } from '../video-player/video-player.component';
import { rxState } from '@rx-angular/state';

interface ExerciseDetailsState {
  exerciseData: ExerciseByIdData | null;
  videoPlayerOptions: VideoPlayerOptions | null;
}

@Component({
  selector: 'app-exercise-details-dialog',
  standalone: false,
  templateUrl: './exercise-details-dialog.component.html',
  styleUrl: './exercise-details-dialog.component.scss',
})
export class ExerciseDetailsDialogComponent implements OnInit {
  private dialogRef: MatDialogRef<ExerciseDetailsDialogComponent> = inject(MatDialogRef<ExerciseDetailsDialogComponent>);
  private exerciseId = inject(MAT_DIALOG_DATA);

  exerciseService = inject(ExerciseService);

  state = rxState<ExerciseDetailsState>(({ set }) => set({
    exerciseData: null,
    videoPlayerOptions: null
  }));

  exerciseData$: Observable<ExerciseByIdData | null> = this.state.select('exerciseData');
  videoPlayerOptions$: Observable<VideoPlayerOptions | null> = this.state.select('videoPlayerOptions');

  ngOnInit(): void {
    this.exerciseService.apiV1ExerciseIdGet(this.exerciseId).pipe(
      map(response => response.data),
    ).subscribe(exerciseData => {
      this.state.set({
        exerciseData: exerciseData,
        videoPlayerOptions: {
          fluid: true,
          autoplay: true,
          controls: true,
          aspectRatio: '16:9',
          sources: exerciseData.videoUrl ? [{ src: exerciseData.videoUrl, type: 'video/mp4' }] : [],
        }
      })
    })
  }
}
