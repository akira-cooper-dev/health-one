import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { ExerciseDetailsDialogComponent } from './exercise-details-dialog/exercise-details-dialog.component';


@NgModule({
  declarations: [ExerciseDetailsDialogComponent],
  imports: [
    CommonModule,
    MatDialogModule
  ]
})
export class SharedModule { }
