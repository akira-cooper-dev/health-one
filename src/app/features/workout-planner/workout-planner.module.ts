import { NgModule } from '@angular/core';
import { WorkoutPlannerComponent } from './workout-planner.component';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { RxPush } from '@rx-angular/template/push';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [WorkoutPlannerComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    RxPush,
    MatInputModule
  ]
})
export class WorkoutPlannerModule { }
