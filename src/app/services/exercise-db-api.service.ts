import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment.development';
import { Observable } from 'rxjs';
import { ExerciseAdvancedFilterRequest, ExerciseByBodypartRequest, ExerciseByEquipmentRequest, ExerciseByMuscleRequest, ExerciseFuzzyMatchingRequest, ExerciseOptionalSearchRequest } from '../models/dto/exercise-db-api/exercise-request.model';
import { ExerciseResponse } from '../models/dto/exercise-db-api/exercise-response';

@Injectable({
  providedIn: 'root'
})
export class ExerciseDbApiService {
  baseUrl = environment.apiUrl;
  httpClient: HttpClient = inject(HttpClient);

  constructor() { }

  getExerciseById(id: string): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/exercises/${id}`);
  }

  getExercisesByBodyParts(request: ExerciseByBodypartRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/bodyparts/${request.bodyPartName}/exercises`, 
      { params: { offset: request.offset, limit: request.limit } });
  }

  getExercisesByEquipment(request: ExerciseByEquipmentRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/equipments/${request.equipmentName}/exercises`, 
      { params: { offset: request.offset, limit: request.limit } });
  }

  getExercisesByMuscle(request: ExerciseByMuscleRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/muscles/${request.muscleName}/exercises`, 
      { params: { offset: request.offset, limit: request.limit, includeSecondary: request.includeSecondary } });
  }

  getExercisesByFuzzyMatching(request: ExerciseFuzzyMatchingRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/exercises/search`, 
      { params: { offset: request.offset, limit: request.limit, q: request.searchQuery, threshold: request.threshold } });
  }

  getExercisesByOptionalSearch(request: ExerciseOptionalSearchRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/exercises`, 
      { params: { offset: request.offset, limit: request.limit, search: request.searchQuery, sortBy: request.sortBy, sortOrder: request.sortOrder } });
  }

  getExercisesByAdvancedFiltering(request: ExerciseAdvancedFilterRequest): Observable<ExerciseResponse> {
    return this.httpClient.post<ExerciseResponse>(`${this.baseUrl}/exercises/filter`, 
      { params: { offset: request.offset, limit: request.limit, search: request.searchQuery, muscles: request.muscles, equipment: request.equipment, bodyParts: request.bodyParts, sortBy: request.sortBy, sortOrder: request.sortOrder } });
  }

  getAllMuscles(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.baseUrl}/muscles`);
  }

  getAllEquipments(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.baseUrl}/equipments`);
  }

  getAllBodyParts(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.baseUrl}/bodyparts`);
  }
}
