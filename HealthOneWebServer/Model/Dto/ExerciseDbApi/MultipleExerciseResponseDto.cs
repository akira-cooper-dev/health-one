namespace HealthOneWebServer.Model.Dto.ExerciseDbApi
{
  public class MultipleExerciseResponseDto
  {
    public bool Success { get; set; }
    public List<ExerciseEntity>? Data { get; set; }
    public Metadata? Metadata { get; set; }
  }
}
