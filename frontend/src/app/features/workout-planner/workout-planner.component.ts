import { ChangeDetectionStrategy, Component, DestroyRef, inject, OnInit } from '@angular/core';
import { catchError, filter, map, Observable, of, switchMap, tap } from 'rxjs';
import { ExerciseDbApiService } from '../../services/exercise-db-api.service';
import { ExerciseEntity } from '../../models/entity/exercise-entity';
import { FormBuilder } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatDialog } from '@angular/material/dialog';
import { ExerciseDetailsDialogComponent } from '../shared/exercise-details-dialog/exercise-details-dialog.component';
import { rxState } from '@rx-angular/state';
import { ExerciseResponse } from '../../models/dto/exercise-db-api/exercise-response';

interface WorkoutPlannerState {
  exerciseResult: ExerciseResponse | null;
  isLoading: boolean;
}

@Component({
  selector: 'app-workout-planner',
  standalone: false,
  templateUrl: './workout-planner.component.html',
  styleUrl: './workout-planner.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WorkoutPlannerComponent implements OnInit {
  destroyRef = inject(DestroyRef);
  fb = inject(FormBuilder);
  dialogService = inject(MatDialog);

  formGroup = this.fb.group({
    searchQuery: ''
  });

  private state = rxState<WorkoutPlannerState>
    (({ set }) => set({
      exerciseResult: null,
      isLoading: false
    }))
  exerciseResults$: Observable<ExerciseEntity[]> = this.state.select('exerciseResult', 'data');
  isLoading$: Observable<boolean> = this.state.select('isLoading');

  constructor(private apiService: ExerciseDbApiService) { }

  ngOnInit(): void {

  }

  sendSearchRequest(): void {
    of(null).pipe(
      takeUntilDestroyed(this.destroyRef),
      tap(() => this.state.set({ exerciseResult: null, isLoading: true })),
      switchMap(() => this.apiService.getExercisesByFuzzyMatching({
        searchQuery: this.formGroup.get('searchQuery')?.value,
        threshold: 0,
        limit: 25
      })),
      catchError(error => {
        this.state.set({ exerciseResult: null, isLoading: false });
        return of(null);
      }),
      filter(response => !!response),
      map(response => {
        const normalizedResponse = response.data.map(exercise => {
          return {
            ...exercise,
            name: this.getCapitalizedString(exercise.name)
          }
        })
        return { ...response, data: normalizedResponse };
      })
    ).subscribe(response => {
      this.state.set({ exerciseResult: response, isLoading: false });
    });
  }

  getCapitalizedString(str: string): string {
    if (!str) return '';
    const words = str.toLowerCase().split(' ');
    for (let i = 0; i < words.length; i++) {
      words[i] = words[i].charAt(0).toUpperCase() + words[i].slice(1);
    }
    return words.join(' ');
  }

  getCommaSeparatedString(items: string[]): string {
    items = items.map(item => this.getCapitalizedString(item));
    return items.join(', ');
  }

  openExerciseInstructions(exercise: ExerciseEntity): void {
    this.dialogService.open(ExerciseDetailsDialogComponent, {
      data: {
        exercise: exercise
      },
    });
  }

  addExercise(exercise: ExerciseEntity): Observable<boolean> {
    return null;
  }
}
