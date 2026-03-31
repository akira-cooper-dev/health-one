using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.User
{
    public class UserHealthProfile
    {
        [Key]
        public required int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
