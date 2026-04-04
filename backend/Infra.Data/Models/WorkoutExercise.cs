using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models
{
    public class WorkoutExercise : Entity
    {
        [ForeignKey("Workout")]
        [Required]
        public required int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        [ForeignKey("Exercise")]
        [Required]
        public required int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
