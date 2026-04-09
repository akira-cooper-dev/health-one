using System.Runtime.Serialization;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api
{
    [DataContract]
    public enum ExerciseDifficultyType
    {
        [EnumMember(Value = "beginner")]
        Beginner,
        [EnumMember(Value = "intermediate")]
        Intermediate,
        [EnumMember(Value = "advanced")]
        Advanced
    }
}
