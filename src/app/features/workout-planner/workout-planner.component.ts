import { ChangeDetectionStrategy, Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { debounceTime, map, Observable, of, switchMap, takeUntil, tap } from 'rxjs';
import { ExerciseDbApiService } from '../../services/exercise-db-api.service';
import { ExerciseEntity } from '../../models/entity/exercise-entity';
import { ExerciseFuzzyMatchingRequest } from '../../models/dto/exercise-db-api/exercise-request.model';
import { FormBuilder, FormControl } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

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

  formGroup = this.fb.group({
    searchQuery: ''
  });

  exerciseResults$: Observable<ExerciseEntity[]> = of([]);

  constructor(private apiService: ExerciseDbApiService) {}

  ngOnInit(): void {

  }

  sendSearchRequest(): void {
    this.exerciseResults$.pipe(
      takeUntilDestroyed(),
      switchMap(() => {
        const request: ExerciseFuzzyMatchingRequest = {
          searchQuery: this.formGroup.get('searchQuery')?.value,
          threshold: 1
        }
        return this.apiService.getExercisesByFuzzyMatching(request);
      }),
      map(response => response.data)
    ).subscribe();
  }
}
