using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.User
{
    public class UserHealthProfile : Entity
    {
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
