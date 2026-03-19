using HealthOneWebServer.API;
using HealthOneWebServer.Model.Dto.ExerciseDbApi;

namespace HealthOneWebServer.Services.Exercises
{
  public class ExercisesService
  {
    private readonly ExerciseDbApiClient _client;

    public ExercisesService(ExerciseDbApiClient client)
    {
      _client = client;
    }

    public async Task<SingleExerciseResponseDto> GetExerciseById(string id)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/{id}";
      var result = await _client.GetAsync<SingleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByBodyParts(ExerciseRequestQueryParameters queryParams, string bodyPartName)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/bodyparts/{bodyPartName}/exercises?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByEquipment(ExerciseRequestQueryParameters queryParams, string equipmentName)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/equipments/{equipmentName}/exercises?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByMuscle(ExerciseRequestQueryParameters queryParams, string muscleName)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/muscles/{muscleName}/exercises?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByFuzzyMatching(ExerciseRequestQueryParameters queryParams)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/search?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByOptionalSearch(ExerciseRequestQueryParameters queryParams)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

    public async Task<MultipleExerciseResponseDto> GetExercisesByAdvancedFiltering(ExerciseRequestQueryParameters queryParams)
    {
      string fullUri = $"{ExerciseDbApiClient.GetBaseUri()}/exercises/filter?{ExerciseDbApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<MultipleExerciseResponseDto>(fullUri);
      return result;
    }

  }
}
