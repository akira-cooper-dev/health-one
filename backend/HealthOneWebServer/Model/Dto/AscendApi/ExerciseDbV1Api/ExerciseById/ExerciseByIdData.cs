using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.Base;

namespace HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseById
{
    public class ExerciseByIdData : BaseExerciseData
    {
        public List<string> BodyParts { get; set; }
        public List<string> Equipments { get; set; }
        public List<string> ExerciseTips { get; set; }
        public string ExerciseType { get; set; }
        public List<string> Instructions { get; set; }
        public List<string> Keywords { get; set; }
        public string Overview { get; set; }
        public List<string> SecondaryMuscles { get; set; }
        public List<string> TargetMuscles { get; set; }
        public List<string> Variations { get; set; }
        public List<string> RelatedExerciseIds { get; set; }
        public string VideoUrl { get; set; }

    }

}
