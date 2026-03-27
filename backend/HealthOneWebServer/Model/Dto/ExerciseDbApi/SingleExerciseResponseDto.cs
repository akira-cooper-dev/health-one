namespace HealthOneWebServer.Model.Dto.ExerciseDbApi
{
  public class SingleExerciseResponseDto
  {
    public bool Success { get; set; }
    public ExerciseEntity? Data { get; set; }
    public Metadata? Metadata { get; set; }
  }
}
