using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models
{
    public class UserExercise : Entity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
