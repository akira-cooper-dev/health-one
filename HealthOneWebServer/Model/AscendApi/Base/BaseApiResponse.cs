namespace HealthOneWebServer.Model.RapidAPI.Base
{
  public class BaseApiResponse<TData>
  {
    public bool Success { get; set; }
    public virtual required List<TData> Data { get; set; }
    public string? Message { get; set; } // error message

  }
}
