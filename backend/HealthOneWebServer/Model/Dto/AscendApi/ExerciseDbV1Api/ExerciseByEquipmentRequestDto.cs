namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class ExerciseByEquipmentRequestDto
    {
        public string Equipments { get; set; } // comma-separated
        public string Limit { get; set; } // max number of results to return (min = 1, max = 25, default = 10)
        public string After { get; set; } // exercise ID to paginate after (for forward pagination)
        public string Before { get; set; } // exercise ID to paginate before (for backward pagination)
    }
}
