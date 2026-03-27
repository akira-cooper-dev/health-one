import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiHttpInterceptor } from './core/api-http-interceptor';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { RxPush } from '@rx-angular/template/push';
import { WorkoutPlannerModule } from './features/workout-planner/workout-planner.module';
import { SharedModule } from './features/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    WorkoutPlannerModule,
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
