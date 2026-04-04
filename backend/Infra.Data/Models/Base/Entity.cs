using System.ComponentModel.DataAnnotations;

namespace Infra.Data.Models.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
