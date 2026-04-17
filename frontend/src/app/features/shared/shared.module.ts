import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { ExerciseDetailsDialogComponent } from './exercise-details-dialog/exercise-details-dialog.component';
import { VideoPlayerComponent } from './video-player/video-player.component';
import { RxPush } from '@rx-angular/template/push';
import { RxIf } from '@rx-angular/template/if';


@NgModule({
  declarations: [ExerciseDetailsDialogComponent, VideoPlayerComponent],
  imports: [
    CommonModule,
    MatDialogModule,
    RxPush,
    RxIf
  ]
})
export class SharedModule { }
