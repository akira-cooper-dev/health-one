import { ExerciseEntity } from "../../entity/exercise-entity";

export interface ExerciseResponse {
    data: ExerciseEntity[] | ExerciseEntity;
    metadata: ExerciseMetadata;
    success: boolean;
}

export interface ExerciseMetadata {
    currentPage: number;
    nextPage: string | null;
    previousPage: string | null;
    totalExercises: number;
    totalPages: number;
}