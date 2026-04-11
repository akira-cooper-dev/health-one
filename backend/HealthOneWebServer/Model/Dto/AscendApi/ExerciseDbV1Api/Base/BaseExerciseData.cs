using System.ComponentModel.DataAnnotations;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.Base
{
    public abstract class BaseExerciseData
    {
        [Required]
        public string ExerciseId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
