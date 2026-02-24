using HealthOneWebServer.API.Remote;

namespace HealthOneWebServer.API
{
  public class AscendApiClient : BaseApiClient
  {
    private static string baseUrl = "https://exercisedb.dev/";
    public AscendApiClient(HttpClient httpClient) : base(httpClient) { }


  }
}
