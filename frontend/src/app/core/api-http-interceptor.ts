import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environment/environment.development';

@Injectable()
export class ApiHttpInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const baseUrl = environment.apiUrl;
    const apiReq = request.clone({ url: `${baseUrl}${request.url}` });
    return next.handle(apiReq);
  }
}