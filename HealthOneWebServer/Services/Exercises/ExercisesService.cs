using HealthOneWebServer.API;
using HealthOneWebServer.API.Remote;
using HealthOneWebServer.Model.AscendApi.Exercises;
using HealthOneWebServer.Model.RapidAPI.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace HealthOneWebServer.Services.Exercises
{
  public class ExercisesService
  {
    private readonly AscendApiClient _client;

    public ExercisesService(AscendApiClient client)
    {
      _client = client;
    }

    public async Task<IActionResult> GetExerciseById(string id)
    {
      string fullUri = $"{AscendApiClient.GetBaseUri()}/exercises/{id}";
      var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
      return new OkObjectResult(result);
    }

    public async Task<IActionResult> GetExercisesByBodyParts(BodyPartsQueryParams queryParams, string bodyPartName)
    {
      string fullUri = $"{AscendApiClient.GetBaseUri()}/bodyparts/{bodyPartName}/exercises/{AscendApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
      return new OkObjectResult(result);
    }

    public async Task<IActionResult> GetExercisesByEquipment(EquipmentQueryParams queryParams, string equipmentName)
    {
      string fullUri = $"{AscendApiClient.GetBaseUri()}/equipments/{equipmentName}/exercises/{AscendApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
      return new OkObjectResult(result);
    }

    public async Task<IActionResult> GetExercisesByMuscle(MuscleQueryParams queryParams, string muscleName)
    {
      string fullUri = $"{AscendApiClient.GetBaseUri()}/muscles/{muscleName}/exercises/{AscendApiClient.CreateUriQueryString(queryParams)}";
      var result = await _client.GetAsync<ExerciseResponseDto>(fullUri);
      return new OkObjectResult(result);
    }
  }
}
