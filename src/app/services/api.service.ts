import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environment/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = environment.apiUrl;
  httpClient: HttpClient = inject(HttpClient);

  constructor() { }

  getAllExercises(): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/exercises`);
  }

  getExerciseById(id: string): Observable<any> {
    return this.httpClient.get(`${this.baseUrl}/exercises/${id}`);
  }

  getExercisesByBodyPartName(bodyPartName: string, queryParams: any): Observable<any> {
    return this.httpClient.post(`${this.baseUrl}/bodyparts/${bodyPartName}/exercises`, { params: queryParams });
  }
}
