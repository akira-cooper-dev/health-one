using Infra.Data.Models;
using Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ExerciseRepository : CRUDRepository<Exercise>
    {
        public ExerciseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Exercise?> GetByApiId(string apiId)
        {
            return await _dbContext.Set<Exercise>().FirstOrDefaultAsync(e => e.ApiId == apiId);
        }
    }
}
