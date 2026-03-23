import { Component, OnInit, signal } from '@angular/core';
import { debounceTime, map, Observable, of, switchMap, tap } from 'rxjs';
import { ExerciseDbApiService } from '../../services/exercise-db-api.service';
import { ExerciseEntity } from '../../models/entity/exercise-entity';
import { ExerciseFuzzyMatchingRequest } from '../../models/dto/exercise-db-api/exercise-request.model';

@Component({
  selector: 'app-workout-planner',
  standalone: false,
  templateUrl: './workout-planner.component.html',
  styleUrl: './workout-planner.component.scss'
})
export class WorkoutPlannerComponent implements OnInit {
  searchQuery$ = signal<string>('');
  exerciseResults$: Observable<ExerciseEntity[]> = of([]);

  constructor(private apiService: ExerciseDbApiService) {}

  ngOnInit(): void {

  }

  sendSearchRequest(event: any): void {
    this.exerciseResults$.pipe(
      switchMap(query => {
        const request: ExerciseFuzzyMatchingRequest = {
          searchQuery: event.target.value,
          threshold: 1
        }
        return this.apiService.getExercisesByFuzzyMatching(request);
      }),
      map(response => response.data)
    ).subscribe();
  }
}
