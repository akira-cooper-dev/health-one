using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Models.Workout
{
    public class Workout : NamedEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User.User User { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
