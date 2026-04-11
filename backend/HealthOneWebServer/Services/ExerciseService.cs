using HealthOneWebServer.ApiClient.AscendApi;
using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseById;
using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseFilter;
using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseSearch;
using Infra.Data.Repositories;

namespace HealthOneWebServer.Services
{
    public class ExerciseService
    {
        private readonly ExerciseDbV1ApiClient _client; // for external API requests
        private readonly ExerciseRepository _exerciseRepo;

        public ExerciseService(ExerciseDbV1ApiClient client, ExerciseRepository exerciseRepo)
        {
            _client = client;
            _exerciseRepo = exerciseRepo;
        }

        #region ExerciseDbV1Api
        public async Task<ExerciseByIdResponseDto> GetExerciseById(string id)
        {
            string requestUri = $"exercises/{id}";
            return await _client.GetAsync<ExerciseByIdResponseDto>(requestUri);
        }

        public async Task<ExerciseSearchResponseDto> GetExercisesBySearchWithFuzzyMatching(ExerciseSearchRequestDto request)
        {
            string requestUri = $"exercises/search?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseSearchResponseDto>(requestUri);
            return result;
        }

        public async Task<ExerciseFilterResponseDto> GetExercisesByAdvancedFiltering(ExerciseFilterRequestDto request)
        {
            string requestUri = $"exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseFilterResponseDto>(requestUri);
            return result;
        }
        #endregion

        #region Database CRUD Operations
        public async Task<Infra.Data.Models.Exercise> AddExercise(Infra.Data.Models.Exercise exercise)
        {
            return await _exerciseRepo.AddAsync(exercise);
        }
        #endregion
    }
}
