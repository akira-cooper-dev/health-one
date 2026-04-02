using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.Workout
{
    public class WorkoutExercise : Entity
    {
        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
