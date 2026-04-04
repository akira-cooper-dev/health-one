using System.ComponentModel.DataAnnotations;

namespace Infra.Data.Models.Base
{
    public class NamedEntity : Entity
    {
        [Required]
        public required string Name { get; set; }
    }
}
