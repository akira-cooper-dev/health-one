using HealthOneWebServer.Model.ExerciseDbApi.Base;

namespace HealthOneWebServer.Model.ExerciseDbApi.Exercise
{
  public class MultipleExerciseResponseDto : BaseApiResponse
  {
    public List<ExerciseDto> Data { get; set; }
  }
}
