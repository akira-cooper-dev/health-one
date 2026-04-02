using Infra.Data.Models;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public class UserRepository : CRUDRepository<User>
    {
        public UserRepository(PostgresDbContext context) : base(context)
        {
        }
    }
}
