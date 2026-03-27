export interface BaseExerciseRequest {
    offset?: number; // The number of exercises to skip from the start of the list. Useful for pagination to fetch subsequent pages of results.
    limit?: number; // min = 1, max = 25 --> The maximum number of exercises to return in the response. Limits the number of results for pagination purposes.
}

export type SortBy = 'name' | 'exerciseId' | 'targetMuscles' | 'bodyParts' | 'equipments';
export type SortOrder = 'asc' | 'desc';