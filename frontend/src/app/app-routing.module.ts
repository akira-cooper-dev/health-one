import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExerciseSearchComponent } from './features/exercise-search/exercise-search.component';

const routes: Routes = [
  { path: "exercise/search", component: ExerciseSearchComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
