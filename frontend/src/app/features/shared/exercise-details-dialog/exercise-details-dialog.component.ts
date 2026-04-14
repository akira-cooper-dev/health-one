import { Component, inject, OnInit } from '@angular/core';
// import { ExerciseEntity } from '../../../models/dto/exercise-db-api/exercise-entity-dto';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-exercise-details-dialog',
  standalone: false,
  templateUrl: './exercise-details-dialog.component.html',
  styleUrl: './exercise-details-dialog.component.scss',
})
export class ExerciseDetailsDialogComponent implements OnInit {
  private dialogRef: MatDialogRef<ExerciseDetailsDialogComponent> = inject(MatDialogRef<ExerciseDetailsDialogComponent>);
  private dialogData = inject(MAT_DIALOG_DATA);
  exercise = null;

  ngOnInit(): void {
  }

  getNormalizedText(steps: string[]): string {
    let normalizedText: string[] = [];

    for (let step of steps) {
      const stepRemoved = step.trim().replace("Step:", "");
      const normalText = stepRemoved.slice(0, 1) + ") " + stepRemoved.slice(1);
      normalizedText.push(normalText);
    }

    return normalizedText.join('\n\n');
  }

}
