using Infra.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Infra.Data.Models
{
    public class User : Entity
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
