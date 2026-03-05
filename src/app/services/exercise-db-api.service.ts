import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExerciseDbApiService {
  private baseUrl = 'https://exercisedb.dev/api/v1/';
  private httpClient: HttpClient = inject(HttpClient);

  constructor() { }

  
  
}
