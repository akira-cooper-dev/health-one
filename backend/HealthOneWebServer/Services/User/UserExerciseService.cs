using Infra.Data.Models;
using Infra.Data.Repositories;

namespace HealthOneWebServer.Services.User
{
    public class UserExerciseService
    {
        private UserExerciseRepository _userExerciseRepo;

        public UserExerciseService(UserExerciseRepository userExerciseRepo)
        {
            _userExerciseRepo = userExerciseRepo;
        }

        public async Task<List<UserExercise>> GetByUserId(int userId)
        {
            return await _userExerciseRepo.GetByUserId(userId);
        }
    }
}
