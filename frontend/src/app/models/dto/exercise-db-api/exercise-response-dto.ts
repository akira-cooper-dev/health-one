import { ExerciseEntity } from "./exercise-entity-dto";

export interface ExerciseResponseDto {
    data: ExerciseEntity[];    // searching by ID will return a single Exercise
    metadata: ExerciseMetadataDto;
    success: boolean;
}

export interface ExerciseMetadataDto {
    currentPage: number;
    nextPage: string | null;
    previousPage: string | null;
    totalExercises: number;
    totalPages: number;
}