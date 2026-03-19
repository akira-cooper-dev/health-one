import { BaseExerciseRequest, SortBy, SortOrder } from "./base-exercise-request";



export interface ExerciseRequestQueryParameters extends BaseExerciseRequest {
    offset?: number; // The number of exercises to skip from the start of the list. Useful for pagination to fetch subsequent pages of results.
    limit?: number; // min = 1, max = 25 --> The maximum number of exercises to return in the response. Limits the number of results for pagination purposes.
    searchQueryAll?: string; // Search term that will be fuzzy matched against exercise names, muscles, equipment, and body parts
    searchQueryExercise?: string; // Optional search term for fuzzy matching across all exercise fields
    searchThreshold?: number; // Fuzzy search threshold (0 = exact match, 1 = very loose match)
    sortBy?: string; // Field to sort exercises by
    sortOrder?: string; // Sort order (ascending or descending)
    muscles?: string; // Comma-separated list of target muscles
    equipment?: string; // Comma-separated list of equipment
    bodyParts?: string; // Comma-separated list of body parts
    includeSecondaryMuscles?: boolean; // Whether to include exercises where this muscle is a secondary target
}

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
    bodyPartName: string; // Body part name (case-sensitive)
}

export interface ExerciseByEquipmentRequest extends BaseExerciseRequest {
    equipmentName: string; // Equipment name (case-sensitive)
}

export interface ExerciseByMuscleRequest extends BaseExerciseRequest {
    muscleName: string; // Target muscle name (case-sensitive)
}