
using HealthOneWebServer.ApiClient.Base;

namespace HealthOneWebServer.ApiClient
{
  public class ExerciseDbApiClient : BaseApiClient
  {
    private static string baseUrl = "https://exercisedb.dev/api/v1";
    public static string GetBaseUri() { return baseUrl; }

    public ExerciseDbApiClient(HttpClient httpClient) : base(httpClient) { }

  }
}
