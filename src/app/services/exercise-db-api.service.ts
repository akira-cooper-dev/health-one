import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment.development';
import { Observable } from 'rxjs';
import { ExerciseRequestQueryParameters } from '../models/dto/exercise-db-api/exercise-request-query-parameters.model';

@Injectable({
  providedIn: 'root'
})
export class ExerciseDbApiService {
  baseUrl = environment.apiUrl;
  httpClient: HttpClient = inject(HttpClient);

  constructor() { }

  getAllExercises(): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/exercises`);
  }

  getExerciseById(id: string): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/exercises/${id}`);
  }

  getExercisesByBodyParts(bodyPartName: string, queryParams: ExerciseRequestQueryParameters): Observable<any> {
    return this.httpClient.post(`${this.baseUrl}/bodyparts/${bodyPartName}/exercises`, { params: queryParams });
  }

  getExercisesByEquipment(equipmentName: string, queryParams: ExerciseRequestQueryParameters): Observable<any> {
    return this.httpClient.post(`${this.baseUrl}/equipments/${equipmentName}/exercises`, { params: queryParams });
  }

  getExercisesByMuscle(muscleName: string, queryParams: ExerciseRequestQueryParameters): Observable<any> {
    return this.httpClient.post(`${this.baseUrl}/muscles/${muscleName}/exercises`, { params: queryParams });
  }
}
