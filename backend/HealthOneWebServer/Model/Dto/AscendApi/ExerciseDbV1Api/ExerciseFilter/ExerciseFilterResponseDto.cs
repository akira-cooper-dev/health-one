using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.Core;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseFilter
{
    public class ExerciseFilterResponseDto
    {
        public bool Success { get; set; }
        public List<ExerciseFilterData> Data { get; set; }
        public Metadata? Meta { get; set; }
    }
}
