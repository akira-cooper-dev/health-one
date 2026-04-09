namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class ExerciseFilterRequestDto
    {
        public string Name { get; set; }
        public string TargetMuscles { get; set; } // comma-separated
        public string SecondaryMuscles { get; set; } // comma-separated
        public string ExerciseTypes { get; set; }   // comma-separated
        public ExerciseDifficultyType Difficulty { get; set; }  // beginner, intermediate, advanced
        public string BodyParts { get; set; } // comma-separated
        public string Equipments { get; set; } // comma-separated
        public string Limit { get; set; } // max number of results to return (min = 1, max = 25, default = 10)
        public string After { get; set; } // exercise ID to paginate after (for forward pagination)
        public string Before { get; set; } // exercise ID to paginate before (for backward pagination)
    }
}
