namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseFilter
{
    public class ExerciseFilterRequestDto
    {
        public string Name { get; set; }
        public string Keywords { get; set; } // comma-separated
        public string TargetMuscles { get; set; } // comma-separated
        public string SecondaryMuscles { get; set; } // comma-separated
        public string ExerciseType { get; set; }   // comma-separated
        public string BodyParts { get; set; } // comma-separated
        public string Equipments { get; set; } // comma-separated
        public string Limit { get; set; } // max number of results to return (min = 1, max = 25, default = 10)
        public string After { get; set; } // exercise ID to paginate after (for forward pagination)
        public string Before { get; set; } // exercise ID to paginate before (for backward pagination)
    }
}
