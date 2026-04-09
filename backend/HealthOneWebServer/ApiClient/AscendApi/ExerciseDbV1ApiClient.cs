using HealthOneWebServer.ApiClient.Base;

namespace HealthOneWebServer.ApiClient.AscendApi
{
    public class ExerciseDbV1ApiClient : BaseApiClient
    {
        private static string baseUri = "https://edb-with-videos-and-images-by-ascendapi.p.rapidapi.com/api/v1/";
        public static string GetBaseUri() { return baseUri; }

        public ExerciseDbV1ApiClient(HttpClient httpClient) : base(httpClient) { }

    }
}
