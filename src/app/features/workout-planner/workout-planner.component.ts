import { ChangeDetectionStrategy, Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { debounceTime, map, Observable, of, switchMap, takeUntil, tap } from 'rxjs';
import { ExerciseDbApiService } from '../../services/exercise-db-api.service';
import { ExerciseEntity } from '../../models/entity/exercise-entity';
import { ExerciseFuzzyMatchingRequest } from '../../models/dto/exercise-db-api/exercise-request.model';
import { FormBuilder, FormControl } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatDialog } from '@angular/material/dialog';

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

  exerciseResults$: Observable<ExerciseEntity[]> = of([]);

  constructor(private apiService: ExerciseDbApiService) {}

  ngOnInit(): void {

  }

  sendSearchRequest(): void {
    this.exerciseResults$ = this.apiService.getExercisesByFuzzyMatching({
      searchQuery: this.formGroup.get('searchQuery')?.value,
      threshold: 0,
      limit: 25
    }).pipe(
      map(response => response.data),
      tap(data => console.log(data))
    )
  }

  getCapitalizedString(name: string): string {
    const words = name.toLowerCase().split(' ');
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
    
  }
}
