using HealthOneWebServer.Model.ExerciseDbApi.Dto;

namespace HealthOneWebServer.Model.ExerciseDbApi.Exercise
{
  public class SingleExerciseResponseDto
  {
    public bool Success { get; set; }
    public ExerciseEntity? Data { get; set; }
    public MetaData? Metadata { get; set; }
  }
}
