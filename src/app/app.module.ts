import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SelectModule } from 'primeng/select';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { WorkoutRoutineModule } from './features/workout-routine/workout-routine.module';
import { PanelCardModule } from './features/shared/panel-card/panel-card.module';
import { ApiHttpInterceptor } from './core/api-http-interceptor';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {provideAnimations} from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SelectModule,
    ReactiveFormsModule,
    FormsModule,
    WorkoutRoutineModule,
    PanelCardModule,
    MatButtonToggleModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiHttpInterceptor,
      multi: true
    },
    provideHttpClient(),
    provideAnimations()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
