using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.Base;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseFilter
{
    public class ExerciseFilterData : BaseExerciseData
    {
        public List<string> BodyParts { get; set; }
        public List<string> Equipments { get; set; }
        public string ExerciseType { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> SecondaryMuscles { get; set; }
        public List<string> TargetMuscles { get; set; }
    }
}
