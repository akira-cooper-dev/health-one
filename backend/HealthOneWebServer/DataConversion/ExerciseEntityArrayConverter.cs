using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HealthOneWebServer.DataConversion
{
    // For Exercise DB V1 API response - handles cases where the API returns either a single exercise object or an array of exercise objects
    public class ExerciseEntityArrayConverter : JsonConverter<List<ExerciseEntity>>
    {
        public override List<ExerciseEntity>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                return JsonSerializer.Deserialize<List<ExerciseEntity>>(ref reader, options);
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                var single = JsonSerializer.Deserialize<ExerciseEntity>(ref reader, options);
                return single != null ? new List<ExerciseEntity> { single } : new List<ExerciseEntity>();
            }
            return new List<ExerciseEntity>();
        }

        public override void Write(Utf8JsonWriter writer, List<ExerciseEntity> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}