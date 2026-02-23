import { Component, computed, OnInit, signal } from '@angular/core';
import { CardItem } from '../shared/panel-card/panel-card.component';
import { Observable } from 'rxjs';
import { ExerciseService } from '../../services/exercise.service';
import { ExerciseByTargetMuscleRequest } from '../../models/dto/exercise.model';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Muscle } from '../../models/exercises/muscle.model';

enum FilterCategory {
  Muscle = "Muscle",
  BodyPart = "Body Part",
  Equipment = "Equipment",
  ExerciseName = "Exercise Name"
}

@Component({
  selector: 'app-workout-routine',
  standalone: false,
  templateUrl: './workout-routine.component.html',
  styleUrl: './workout-routine.component.scss'
})
export class WorkoutRoutineComponent implements OnInit {

  filterControl: FormControl<FilterCategory> = new FormControl<FilterCategory>(FilterCategory.Muscle);
  filterCategoryEnum = FilterCategory;
  muscleList = Object.keys(Muscle);
  formGroup: FormGroup;

  selectedTabIndex = 0;
  tabs = ["Muscle", "Body Part", "Equipment", "Exercise"];

  constructor(
    private exerciseSvc: ExerciseService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.createFormGroup();
  }

  createFormGroup() {
    this.formGroup = this.fb.group({
      muscles: this.fb.control([]),
      bodyParts: this.fb.control([]),
      equipment: this.fb.control([]),
      exerciseNames: this.fb.control([])
    })
  }
}
