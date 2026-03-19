import { BaseExerciseRequest, SortBy, SortOrder } from "./base-exercise-request";

export interface ExerciseFuzzyMatchingRequest extends BaseExerciseRequest {
    searchQuery: string; // Search term that will be fuzzy matched against exercise names, muscles, equipment, and body parts
    threshold?: number // 0 = exact match, 1 = very loose match
}

export interface ExerciseOptionalSearchRequest extends BaseExerciseRequest {
    searchQuery?: string // Optional search term for fuzzy matching across all exercise fields
    sortBy?: SortBy; // Field to sort exercises by
    sortOrder?: SortOrder; // Sort order (ascending or descending)
}

export interface ExerciseAdvancedFilterRequest extends BaseExerciseRequest {
    searchQuery?: string; // Optional search term for fuzzy matching across all exercise fields
    muscles?: string; // Comma-separated list of target muscles
    equipment?: string; // Comma-separated list of equipment
    bodyParts?: string; // Comma-separated list of body parts
    sortBy?: SortBy; // Field to sort exercises by
    sortOrder?: SortOrder; // Sort order (ascending or descending)
}

export interface ExerciseByBodypartRequest extends BaseExerciseRequest {
    bodyPartName: string; // case-sensitive
}

export interface ExerciseByEquipmentRequest extends BaseExerciseRequest {
    equipmentName: string; // case-sensitive
}

export interface ExerciseByMuscleRequest extends BaseExerciseRequest {
    muscleName: string; // Target muscle name (case-sensitive)
    includeSecondary: boolean; // Whether to include exercises where this muscle is a secondary target
}