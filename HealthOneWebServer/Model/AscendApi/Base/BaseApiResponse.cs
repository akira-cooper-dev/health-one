namespace HealthOneWebServer.Model.RapidAPI.Base
{
  public class BaseApiResponse
  {
    public bool Success { get; set; }
    public object? MetaData { get; set; }
    public object[] Data { get; set; }
    public string? Message { get; set; } // error message

  }
}
