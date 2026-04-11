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

        public async Task<List<UserExerciseDto>> GetAllExercisesByUserId(int userId)
        {
            var exercises = await _userExerciseRepo.GetAllExercisesByUserId(userId);
            return exercises.Select(e => new UserExerciseDto
            {
                Id = e.Id,
                UserId = e.UserId,
                ExerciseId = e.ExerciseId
            }).ToList();
        }

        public async Task<UserExerciseDto> AddUserExercise(CreateUserExerciseRequestDto dto)
        {
            Exercise? match = await _exerciseRepo.GetByApiId(dto.ExerciseApiId);

            if (match == null)
            {
                // create new Exercise first if no match is found
                var newExercise = await _exerciseRepo.AddAsync(new Exercise
                {
                    ApiId = dto.ExerciseApiId,
                    Name = dto.ExerciseName,
                    Time = dto.Time
                });

                var newUserExercise = await _userExerciseRepo.AddAsync(new UserExercise
                {
                    UserId = dto.UserId,
                    ExerciseId = newExercise.Id
                });

                return new UserExerciseDto
                {
                    Id = newUserExercise.Id,
                    UserId = newUserExercise.UserId,
                    ExerciseId = newUserExercise.ExerciseId
                };
            }

            UserExercise result = await _userExerciseRepo.AddAsync(new UserExercise
            {
                UserId = dto.UserId,
                ExerciseId = match.Id
            });

            return new UserExerciseDto
            {
                Id = result.Id,
                UserId = result.UserId,
                ExerciseId = result.ExerciseId
            };
        }
    }
}
