
using HealthOneWebServer.API.Base;

namespace HealthOneWebServer.API
{
  public class ExerciseDbApiClient : BaseApiClient
  {
    private static string baseUrl = "https://exercisedb.dev/api/v1";
    public static string GetBaseUri() { return baseUrl; }

    public ExerciseDbApiClient(HttpClient httpClient) : base(httpClient) { }

  }
}
