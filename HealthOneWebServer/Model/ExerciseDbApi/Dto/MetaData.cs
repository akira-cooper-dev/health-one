namespace HealthOneWebServer.Model.ExerciseDbApi.Dto
{
  public class MetaData
  {
    public int CurrentPage { get; set; }
    public string? NextPage { get; set; }
    public string? PreviousPage { get; set; }
    public int TotalExercises { get; set; }
    public int TotalPages { get; set; }
  }
}
