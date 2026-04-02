using Infra.Data.Models;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public class WorkoutRepository : CRUDRepository<Workout>
    {
        public WorkoutRepository(PostgresDbContext context) : base(context)
        {
        }
    }
}
