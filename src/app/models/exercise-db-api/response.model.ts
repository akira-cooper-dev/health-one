export interface ExerciseDbApiResponse {
    success: boolean;
    metadata?: object;
    data: object[];
}

interface BaseExerciseRequestQueryParams {
    offset?: number | null;
    limit?: number | null;
}

export interface BodyPartsQueryParams extends BaseExerciseRequestQueryParams {}
export interface EquipmentQueryParams extends BaseExerciseRequestQueryParams {}
export interface MuscleQueryParams extends BaseExerciseRequestQueryParams {
    includeSecondaryMuscle: boolean
}