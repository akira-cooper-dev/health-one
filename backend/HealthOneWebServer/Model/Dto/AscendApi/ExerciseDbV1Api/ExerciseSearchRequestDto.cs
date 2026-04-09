namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class ExerciseSearchRequestDto
    {
        public string SearchQuery { get; set; } // search query with fuzzy matching

        public decimal Threshold { get; set; } // fuzzy search threshold (0 = exact match, 1 = very loose match); default = 0.4
    }
}
