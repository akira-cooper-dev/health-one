using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.User
{
    public class UserExercise
    {
        [Key]
        public required int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
