import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environment/environment.development';

@Injectable({
    providedIn: 'root'
})
export class BaseApiService {
    baseUri = environment.apiUri;
    httpClient: HttpClient = inject(HttpClient);
}