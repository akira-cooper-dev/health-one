using HealthOneWebServer.Model.RapidAPI.Base;
using HealthOneWebServer.Model.RapidAPI.Exercises;

namespace HealthOneWebServer.Model.AscendApi.Exercises
{
  public class ExerciseResponseDto : BaseApiResponse<ExerciseDto>
  {
    public override required List<ExerciseDto> Data { get; set; }
    public MetaData? MetaData { get; set; }
  }
}
