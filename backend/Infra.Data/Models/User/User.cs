using Infra.Data.Models.Base;

namespace Infra.Data.Models.User
{
    public class User : Entity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
