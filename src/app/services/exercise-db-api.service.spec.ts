import { TestBed } from '@angular/core/testing';

import { ExerciseDbApiService } from './exercise-db-api.service';

describe('ExerciseDbApiService', () => {
  let service: ExerciseDbApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExerciseDbApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
