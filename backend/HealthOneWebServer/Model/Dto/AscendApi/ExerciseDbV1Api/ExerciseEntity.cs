namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class ExerciseEntity
    {
        public required string ExerciseId { get; set; }
        public required string Name { get; set; }
        public List<string>? Equipments { get; set; }
        public List<string>? BodyParts { get; set; }
        public List<string>? ExerciseTypes { get; set; }
        public ExerciseDifficultyType? Difficulty { get; set; }
        public List<string>? TargetMuscles { get; set; }
        public List<string>? SecondaryMuscles { get; set; }
        public string? ImageUrl { get; set; }

    }
}
