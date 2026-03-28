import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiHttpInterceptor } from './core/api-http-interceptor';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { RxPush } from '@rx-angular/template/push';
import { ExerciseSearchModule } from './features/exercise-search/exercise-search.module';
import { SharedModule } from './features/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ExerciseSearchModule,
    SharedModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiHttpInterceptor,
      multi: true
    },
    provideHttpClient(),
    provideAnimations(),
    RxPush
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
