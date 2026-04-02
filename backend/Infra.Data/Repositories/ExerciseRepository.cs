using Infra.Data.Models;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public class ExerciseRepository : CRUDRepository<Exercise>
    {
        public ExerciseRepository(PostgresDbContext context) : base(context)
        {
        }
    }
}
