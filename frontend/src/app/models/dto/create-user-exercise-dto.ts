
export interface CreateUserExerciseDto {
    userId: number;
    exerciseApiId: string; // The exerciseId from the Exercise DB API
    exerciseName: string;
    time?: string;  // length of exercise in hh:mm:ss format (optional)
}