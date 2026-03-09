using HealthOneWebServer.Model.ExerciseDbApi.Base;

namespace HealthOneWebServer.Model.ExerciseDbApi.Exercise
{
  public class SingleExerciseResponseDto : BaseApiResponse
  {
    public ExerciseDto? Data { get; set; }
  }
}
