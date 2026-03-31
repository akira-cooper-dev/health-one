using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.Workout
{
    public class WorkoutExercise
    {
        [Key]
        public required int Id { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
