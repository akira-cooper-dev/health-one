import { Observable } from 'rxjs';
import { ExerciseAdvancedFilterRequestDto, ExerciseByBodypartRequestDto, ExerciseByEquipmentRequestDto, ExerciseByMuscleRequestDto, ExerciseFuzzyMatchingRequestDto, ExerciseOptionalSearchRequestDto } from '../models/dto/exercise-db-api/exercise-request-dto';
import { ExerciseResponseDto } from '../models/dto/exercise-db-api/exercise-response-dto';
import { BaseApiService } from './base/base-api-service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExerciseDbApiService extends BaseApiService {

  endpointUri = `${this.baseUri}/exercise`;

  getExerciseById(id: string): Observable<ExerciseResponseDto> {
    return this.httpClient.get<ExerciseResponseDto>(`${this.endpointUri}/${id}`);
  }

  getExercisesByBodyParts(request: ExerciseByBodypartRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/bodypart/${request.bodyPartName}`,
      { offset: request.offset, limit: request.limit });
  }

  getExercisesByEquipment(request: ExerciseByEquipmentRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/equipment/${request.equipmentName}`,
      { offset: request.offset, limit: request.limit });
  }

  getExercisesByMuscle(request: ExerciseByMuscleRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/muscle/${request.muscleName}`,
      { offset: request.offset, limit: request.limit, includeSecondary: request.includeSecondary });
  }

  getExercisesByFuzzyMatching(request: ExerciseFuzzyMatchingRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/search`,
      { offset: request.offset, limit: request.limit, q: request.searchQuery, threshold: request.threshold });
  }

  getExercisesByOptionalSearch(request: ExerciseOptionalSearchRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/optional-search`,
      { offset: request.offset, limit: request.limit, search: request.searchQuery, sortBy: request.sortBy, sortOrder: request.sortOrder });
  }

  getExercisesByAdvancedFiltering(request: ExerciseAdvancedFilterRequestDto): Observable<ExerciseResponseDto> {
    return this.httpClient.post<ExerciseResponseDto>(`${this.endpointUri}/filter`,
      { offset: request.offset, limit: request.limit, search: request.searchQuery, muscles: request.muscles, equipment: request.equipment, bodyParts: request.bodyParts, sortBy: request.sortBy, sortOrder: request.sortOrder });
  }

  getAllMuscles(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.endpointUri}/muscles`);
  }

  getAllEquipments(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.endpointUri}/equipments`);
  }

  getAllBodyParts(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.endpointUri}/bodyparts`);
  }
}
