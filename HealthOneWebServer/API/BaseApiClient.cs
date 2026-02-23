using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HealthOneWebServer.API.Remote
{
  public abstract class BaseApiClient
  {
    private readonly HttpClient _httpClient;

    public BaseApiClient(HttpClient httpClient)
    {
      _httpClient = httpClient;
      
    }

    public virtual async Task<TResponse> GetAsync<TResponse>(string requestUri)
    {
      var response = await _httpClient.GetAsync(requestUri);
      response.EnsureSuccessStatusCode();

      var content = await response.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<TResponse>(content, new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      });
    }

    public static string CreateUrlQueryString<T>(T obj)
    {
      string queryString = string.Empty;
      Type type = obj.GetType();
      PropertyInfo[] properties = type.GetProperties();

      foreach (var param in properties)
      {
        if (param != null && !String.IsNullOrWhiteSpace(param?.GetValue(obj)?.ToString()))
        {
          queryString += param.Name.ToLower() + "=" + param?.GetValue(obj)?.ToString().ToLower() + "&";
        }
      }

      queryString = queryString.Remove(queryString.Length - 1);

      return queryString;
    }
  }
}
