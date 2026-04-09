using HealthOneWebServer.ApiClient.AscendApi;
using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api;
using Infra.Data.Repositories;

namespace HealthOneWebServer.Services
{
    public class ExerciseService
    {
        private readonly ExerciseDbV1ApiClient _client; // for external API requests
        private readonly ExerciseRepository _exerciseRepo;
        private readonly string _baseUri = ExerciseDbV1ApiClient.GetBaseUri();

        public ExerciseService(ExerciseDbV1ApiClient client, ExerciseRepository exerciseRepo)
        {
            _client = client;
            _exerciseRepo = exerciseRepo;
        }

        #region ExerciseDbV1Api
        public async Task<ExerciseResponseDto> GetExerciseById(string id)
        {
            string fullUri = $"{_baseUri}/exercises/{id}";
            return await _client.GetAsync<ExerciseResponseDto>(fullUri);
        }

        public async Task<ExerciseResponseDto> GetExercisesByEquipments(ExerciseByEquipmentRequestDto request)
        {
            string fullUri = $"{_baseUri}/exercises/equipments?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<ExerciseResponseDto> GetExercisesByMuscles(ExerciseByMuscleRequestDto request)
        {
            string fullUri = $"{_baseUri}/exercises/muscles?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<ExerciseResponseDto> GetExercisesBySearchFuzzyMatching(ExerciseSearchRequestDto request)
        {
            string fullUri = $"{ExerciseDbV1ApiClient.GetBaseUri()}/exercises/search?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<ExerciseResponseDto> GetExercisesByAdvancedFiltering(ExerciseFilterRequestDto request)
        {
            string fullUri = $"{ExerciseDbV1ApiClient.GetBaseUri()}/exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(request)}";
            var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
            return result;
        }
        #endregion

        #region CRUD Operations
        public async Task<Infra.Data.Models.Exercise> AddExercise(Infra.Data.Models.Exercise exercise)
        {
            return await _exerciseRepo.AddAsync(exercise);
        }
        #endregion
    }
}
