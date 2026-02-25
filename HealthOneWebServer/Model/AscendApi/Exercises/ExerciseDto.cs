namespace HealthOneWebServer.Model.RapidAPI.Exercises
{
  public class ExerciseDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public List<string> SecondaryMuscles { get; set; }
    public List<string> Instructions { get; set; }
    public string BodyPart { get; set; }
    public string Equipment { get; set; }
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
