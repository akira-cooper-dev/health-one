using HealthOneWebServer.Model.ExerciseDbApi.Dto;

namespace HealthOneWebServer.Model.ExerciseDbApi.Exercise
{
  public class MultipleExerciseResponseDto
  {
    public bool Success { get; set; }
    public List<ExerciseEntity>? Data { get; set; }
    public MetaData? Metadata { get; set; }
  }
}
