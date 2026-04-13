import { BaseApiService } from './base/base-api-service';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ExerciseService extends BaseApiService {
    endpointUri = `${this.baseUri}/exercise`;


}