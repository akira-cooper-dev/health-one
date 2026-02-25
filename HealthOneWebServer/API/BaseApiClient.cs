using System.Reflection;
using System.Text;
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

    public static string CreateUriQueryString<T>(T obj)
    {
      if (obj == null)
      {
        return string.Empty;
      }

      Type type = obj.GetType();

      // if type is not object, return its string value
      if (type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime))
      {
        return Uri.EscapeDataString(obj.ToString() ?? string.Empty);
      }

      PropertyInfo[] properties = type.GetProperties();
      var sb = new StringBuilder();

      foreach (var param in properties)
      {
        if (param == null)
        {
          continue;
        }

        var valueObj = param.GetValue(obj);
        if (valueObj == null)
        {
          continue;
        }

        var valueStr = valueObj.ToString();
        if (string.IsNullOrWhiteSpace(valueStr))
        {
          continue;
        }

        var name = param.Name.ToLowerInvariant();
        sb.Append(Uri.EscapeDataString(name));
        sb.Append('=');
        sb.Append(Uri.EscapeDataString(valueStr.ToLowerInvariant()));
        sb.Append('&');
      }

      if (sb.Length == 0)
      {
        return string.Empty;
      }

      // remove trailing '&'
      sb.Length -= 1;

      return sb.ToString();
    }
  }
}
