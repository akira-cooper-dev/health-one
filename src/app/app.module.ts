import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SelectModule } from 'primeng/select';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { PanelCardModule } from './features/shared/panel-card/panel-card.module';
import { ApiHttpInterceptor } from './core/api-http-interceptor';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {provideAnimations} from '@angular/platform-browser/animations';
import { WorkoutPlannerComponent } from './features/workout-planner/workout-planner.component';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    WorkoutPlannerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SelectModule,
    ReactiveFormsModule,
    FormsModule,
    PanelCardModule,
    MatButtonToggleModule,
    MatIconModule,
    MatToolbarModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
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
