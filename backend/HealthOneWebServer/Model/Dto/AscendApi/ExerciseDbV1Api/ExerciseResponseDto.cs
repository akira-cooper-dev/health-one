using HealthOneWebServer.DataConversion;
using System.Text.Json.Serialization;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class ExerciseResponseDto
    {
        public bool Success { get; set; }
        [JsonConverter(typeof(ExerciseEntityArrayConverter))]
        public List<ExerciseEntity>? Data { get; set; }
        public Metadata? Meta { get; set; }
    }
}
