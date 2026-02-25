using HealthOneWebServer.API.Remote;

namespace HealthOneWebServer.API
{
  public class AscendApiClient : BaseApiClient
  {
    private static string baseUrl = "https://exercisedb.dev/api/v1";
    public static string GetBaseUri() { return baseUrl; }

    public AscendApiClient(HttpClient httpClient) : base(httpClient) { }

  }
}
