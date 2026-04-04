using HealthOneWebServer.ApiClient;
using HealthOneWebServer.Model.Dto.ExerciseDbApi;
using Infra.Data.Repositories;

namespace HealthOneWebServer.Services
{
    public class ExerciseService
    {
        private readonly ExerciseDbApiClient _client;
        private readonly ExerciseRepository _exerciseRepo;

        public ExerciseService(ExerciseDbApiClient client, ExerciseRepository exerciseRepo)
        {
            _client = client;
            _exerciseRepo = exerciseRepo;
        }

        #region ExerciseDbApi
        public async Task<MultipleExerciseResponseDto> GetExerciseById(string id)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/{id}";
            var result = await _client.GetAsync<SingleExerciseResponseDto>(fullUri);
            return new MultipleExerciseResponseDto
            {
                Data = result.Data is not null ? new List<ExerciseEntity>(1) { result.Data } : new List<ExerciseEntity>(),
                Metadata = result.Metadata,
                Success = result.Success
            };
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByBodyParts(ExerciseRequestQueryParameters queryParams, string bodyPartName)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/bodyparts/{bodyPartName}/exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByEquipment(ExerciseRequestQueryParameters queryParams, string equipmentName)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/equipments/{equipmentName}/exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByMuscle(ExerciseRequestQueryParameters queryParams, string muscleName)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/muscles/{muscleName}/exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByFuzzyMatching(ExerciseRequestQueryParameters queryParams)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/search?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByOptionalSearch(ExerciseRequestQueryParameters queryParams)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
            return result;
        }

        public async Task<MultipleExerciseResponseDto> GetExercisesByAdvancedFiltering(ExerciseRequestQueryParameters queryParams)
        {
            string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/filter?{ApiClient.Base.BaseApiClient.CreateUriQueryString(queryParams)}";
            var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
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
