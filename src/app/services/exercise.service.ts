import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExerciseByTargetMuscleRequest } from '../models/dto/exercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExerciseService {

  private baseUrl = 'api/v1/exercises';

  constructor(private httpClient: HttpClient) { }

  getExercisesByTargetMuscle(request: ExerciseByTargetMuscleRequest ): Observable<any> {
    const url = `${this.baseUrl}/target/${request.targetMuscle}`
    return this.httpClient.post(url, request);
  }

}
