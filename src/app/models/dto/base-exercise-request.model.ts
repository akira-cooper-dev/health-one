export interface BaseExerciseRequest {
    offset?: number,
    limit?: number,
    sortMethod?: "bodyPart" | "equipment" | "id" | "name" | "target",
    sortOrder?: "ascending" | "descending"
}