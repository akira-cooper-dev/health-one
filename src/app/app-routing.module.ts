import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkoutPlannerComponent } from './features/workout-planner/workout-planner.component';

const routes: Routes = [
  {path: "workout", component: WorkoutPlannerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
