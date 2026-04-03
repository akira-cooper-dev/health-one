using Infra.Data.Models.Base;

namespace Infra.Data.Models
{
    public class Exercise : NamedEntity
    {
        public required string ApiId { get; set; } // this ID is used to make API calls to get actual info for exercise (since we're not allowed to store data as per Terms of Use)
        public TimeOnly Time { get; set; }   // length of exercise

        //public List<string> TargetMuscles { get; set; }
        //public List<string>? SecondaryMuscles { get; set; }
        //public List<string> Instructions { get; set; }
        //public List<string> BodyParts { get; set; }
        //public List<string> Equipments { get; set; }
        //public string? GifUrl { get; set; }
    }
}
