using HealthOneWebServer.Model.RapidAPI.Exercises;
using System.Runtime.Serialization;

namespace HealthOneWebServer.Model.AscendApi.Exercises
{
  public class GetExerciseByBodypartsQueryParams : BaseExerciseRequestQueryParams { }
  public class GetExerciseByEquipmentQueryParams : BaseExerciseRequestQueryParams { }
  public class GetExercisesByMuscleQueryParams : BaseExerciseRequestQueryParams { }

  public class GetExercisesWithOptionalSearch : BaseExerciseRequestQueryParams
  {
    public string SearchQuery { get; set; }
    public SortField SortByField { get; set; }
    public SortOrder SortOrder { get; set; }
  }
  [DataContract]
  public enum SortField
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
