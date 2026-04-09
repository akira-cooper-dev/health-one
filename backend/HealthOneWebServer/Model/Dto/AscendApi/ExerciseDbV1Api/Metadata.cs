namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    public class Metadata
    {
        public int Total { get; set; } // Total number of exercises matching the filters
        public bool HasNextPage { get; set; } // Whether there are more results after the current page
        public bool HasPreviousPage { get; set; } // Whether there are results before the current page
        public string? NextCursor { get; set; } // Cursor for fetching the next page (exercise ID)
        public string? PreviousCursor { get; set; } // Cursor for fetching the previous page (exercise ID)
    }
}
