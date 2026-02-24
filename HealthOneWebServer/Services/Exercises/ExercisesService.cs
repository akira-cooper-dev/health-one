using HealthOneWebServer.API;
using HealthOneWebServer.API.Remote;
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

    public async Task<IActionResult> GetExerciseById(int id)
    {
      string urlQueryString = BaseApiClient.CreateUrlQueryString(id)
    }
    public async Task<IActionResult> GetExercisesByTargetMuscle(BaseExerciseRequestQueryParams? request, string muscle)
    {
      string queryParams = BaseApiClient.CreateUrlQueryString(request);
      string endpoint = $"exercises/target/{muscle}?{queryParams}";
      var result = await _client.GetListAsync<ExerciseResponseDto>(endpoint);
      return new OkObjectResult(result);
    }
  }
}
