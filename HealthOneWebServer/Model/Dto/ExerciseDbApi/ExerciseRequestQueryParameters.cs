using System.Runtime.Serialization;

namespace HealthOneWebServer.Model.Dto.ExerciseDbApi
{
  public class ExerciseRequestQueryParameters
  {
    public int? Offset { get; set; } // The number of exercises to skip from the start of the list. Useful for pagination to fetch subsequent pages of results.
    public int? Limit { get; set; } // min = 1, max = 25 --> The maximum number of exercises to return in the response. Limits the number of results for pagination purposes.
    public string? q { get; set; } // Search term that will be fuzzy matched against exercise names, muscles, equipment, and body parts
    public string? search { get; set; } // Optional search term for fuzzy matching across all exercise fields
    public int? SearchThreshold { get; set; } // Fuzzy search threshold (0 = exact match, 1 = very loose match)
    public SortBy? SortBy { get; set; } // Field to sort exercises by
    public SortOrder? SortOrder { get; set; } // Sort order (ascending or descending)
    public string? Muscles { get; set; } // Comma-separated list of target muscles
    public string? Equipment { get; set; } // Comma-separated list of equipment
    public string? BodyParts { get; set; } // Comma-separated list of body parts
    public bool? IncludeSecondaryMuscles { get; set; } // Whether to include exercises where this muscle is a secondary target
  }

  [DataContract]
  public enum SortBy
  {
    [EnumMember(Value = "name")]
    Name,
    [EnumMember(Value = "exerciseId")]
    ExerciseId,
    [EnumMember(Value = "targetMuscles")]
    TargetMuscles,
    [EnumMember(Value = "bodyParts")]
    BodyParts,
    [EnumMember(Value = "equipments")]
    Equipments
  }
  [DataContract]
  public enum SortOrder
  {
    [EnumMember(Value = "asc")]
    Ascending,
    [EnumMember(Value = "desc")]
    Descending
  }
}
