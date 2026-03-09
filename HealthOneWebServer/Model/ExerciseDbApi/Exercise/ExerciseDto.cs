namespace HealthOneWebServer.Model.ExerciseDbApi.Exercise
{
  public class ExerciseDto
  {
    public string ExerciseId { get; set; }
    public string Name { get; set; }
    public List<string> TargetMuscles { get; set; }
    public List<string> SecondaryMuscles { get; set; }
    public List<string> Instructions { get; set; }
    public List<string> BodyParts { get; set; }
    public List<string> Equipments { get; set; }
    public string GifUrl { get; set; }

  }

  public class MetaData
  {
    public int CurrentPage { get; set; }
    public string NextPage { get; set; }
    public string PreviousPage { get; set; }
    public int TotalExercises { get; set; }
    public int TotalPages { get; set; }
  }
}
