import { NgModule } from '@angular/core';
import { ExerciseSearchComponent } from './exercise-search.component';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { RxPush } from '@rx-angular/template/push';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [ExerciseSearchComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    RxPush,
    MatInputModule,
    MatProgressSpinner
  ]
})
export class ExerciseSearchModule { }
