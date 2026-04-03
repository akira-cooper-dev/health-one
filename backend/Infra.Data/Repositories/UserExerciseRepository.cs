using Infra.Data.Models;
using Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserExerciseRepository : CRUDRepository<UserExercise>
    {
        public UserExerciseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<UserExercise>> GetAllExercisesByUserId(int userId)
        {
            return await _dbContext.Set<UserExercise>().Where(ue => ue.UserId == userId).ToListAsync();
        }

        public async Task<UserExercise> AddExerciseToUser(UserExercise userExercise)
        {
            return await AddAsync(userExercise);
        }
    }
}
