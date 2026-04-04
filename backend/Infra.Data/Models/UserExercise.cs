using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models
{
    public class UserExercise : Entity
    {
        [ForeignKey("User")]
        [Required]
        public required int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Exercise")]
        [Required]
        public required int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
