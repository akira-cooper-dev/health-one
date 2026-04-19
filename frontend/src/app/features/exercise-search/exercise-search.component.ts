import { ChangeDetectionStrategy, Component, DestroyRef, inject } from '@angular/core';
import { catchError, filter, map, Observable, of, switchMap, tap } from 'rxjs';
import { FormBuilder } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatDialog } from '@angular/material/dialog';
import { rxState } from '@rx-angular/state';
import { ExerciseSearchData, ExerciseSearchRequestDto, ExerciseService } from '../../api';
import { ExerciseDetailsDialogComponent } from '../shared/exercise-details-dialog/exercise-details-dialog.component';

interface ExerciseSearchState {
  exerciseData: ExerciseSearchData[] | null;
  isLoading: boolean;
}

@Component({
  selector: 'app-exercise-search',
  standalone: false,
  templateUrl: './exercise-search.component.html',
  styleUrl: './exercise-search.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExerciseSearchComponent {
  destroyRef = inject(DestroyRef);
  fb = inject(FormBuilder);
  dialogService = inject(MatDialog);
  exerciseService = inject(ExerciseService);

  formGroup = this.fb.group({
    searchQuery: ''
  });

  private state = rxState<ExerciseSearchState>
    (({ set }) => set({
      exerciseData: null,
      isLoading: false
    }));

  exerciseResults$: Observable<ExerciseSearchData[]> = this.state.select('exerciseData');
  isLoading$: Observable<boolean> = this.state.select('isLoading');

  sendSearchRequest(): void {
    of(this.formGroup.get('searchQuery')?.value).pipe(
      takeUntilDestroyed(this.destroyRef),
      filter(query => !!query),
      tap(() => this.state.set({ exerciseData: null, isLoading: true })),
      switchMap(() => {
        const request: ExerciseSearchRequestDto = {
          search: this.formGroup.get('searchQuery')?.value || null
        }
        return this.exerciseService.apiV1ExerciseSearchPost(request);
      }),
      map(response => response.data),
      catchError(error => {
        this.state.set({ exerciseData: null, isLoading: false });
        console.error('Error fetching exercise search results:', error);
        return of(null);
      }),
      filter(data => data && data.length > 0)
    ).subscribe(data => {
      this.state.set({ exerciseData: data, isLoading: false });
    });
  }

  openExerciseDetails(exerciseId: string): void {
    this.dialogService.open(ExerciseDetailsDialogComponent, {
      data: exerciseId,
      width: '60vw',
      height: '80vh',
    })
  }

  addExercise(exercise: ExerciseSearchData): void {

  }
}
