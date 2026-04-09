using HealthOneWebServer.Model.Dto.UserExercise;
using Infra.Data.Models;
using Infra.Data.Repositories;

namespace HealthOneWebServer.Services
{
    public class UserExerciseService
    {
        private ExerciseRepository _exerciseRepo;
        private UserExerciseRepository _userExerciseRepo;

        public UserExerciseService(ExerciseRepository exerciseRepo, UserExerciseRepository userExerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
            _userExerciseRepo = userExerciseRepo;
        }

        public async Task<List<UserExercise>> GetAllExercisesByUserId(int userId)
        {
            return await _userExerciseRepo.GetAllExercisesByUserId(userId);
        }

        public async Task<UserExercise> AddUserExercise(CreateUserExerciseDto dto)
        {
            var match = await _exerciseRepo.GetByApiId(dto.ExerciseApiId);

            if (match == null)
            {
                // create new Exercise first if no match is found
                var newExercise = await _exerciseRepo.AddAsync(new Exercise
                {
                    ApiId = dto.ExerciseApiId,
                    Name = dto.ExerciseName,
                    Time = dto.Time
                });

                return await _userExerciseRepo.AddAsync(new UserExercise
                {
                    UserId = dto.UserId,
                    ExerciseId = newExercise.Id
                });
            }

            return await _userExerciseRepo.AddAsync(new UserExercise
            {
                UserId = dto.UserId,
                ExerciseId = match.Id
            });
        }
    }
}
