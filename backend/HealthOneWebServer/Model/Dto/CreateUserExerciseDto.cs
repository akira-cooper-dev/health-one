using System.ComponentModel.DataAnnotations;

namespace HealthOneWebServer.Model.Dto
{
    public class CreateUserExerciseDto
    {
        [Required]
        public required int UserId { get; set; }

        [Required]
        public required string ExerciseApiId { get; set; } // ID from ExerciseDB API for exercise entity

        [Required]
        public required string ExerciseName { get; set; } // also from ExerciseDB API

        public TimeOnly? Time { get; set; }   // length of exercise
    }
}
