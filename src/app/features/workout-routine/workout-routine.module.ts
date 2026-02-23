import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelCardModule } from '../shared/panel-card/panel-card.module';
import { WorkoutRoutineComponent } from './workout-routine.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DataViewModule } from 'primeng/dataview';
import {SelectButtonModule} from 'primeng/selectbutton';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatTabsModule} from '@angular/material/tabs';

@NgModule({
  declarations: [WorkoutRoutineComponent],
  imports: [
    CommonModule,
    PanelCardModule,
    ReactiveFormsModule,
    DataViewModule,
    SelectButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTabsModule
  ]
})
export class WorkoutRoutineModule { }
