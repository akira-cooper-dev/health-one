import { BaseExerciseRequest } from "./base-exercise-request.model";

export interface ExerciseByTargetMuscleRequest extends BaseExerciseRequest {
    targetMuscle: string    
}