using Microsoft.AspNetCore.Mvc;
using HealthOneWebServer.Model.RapidAPI.Exercises;
using HealthOneWebServer.Services.Exercises;
using HealthOneWebServer.Model.AscendApi.Exercises;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthOneWebServer.Controllers.API
{
  [Route("api/v1")]
  [ApiController]
  public class ExercisesController : ControllerBase
  {
    private readonly ExercisesService _exercisesService;

    public ExercisesController(ExercisesService service)
    {
      _exercisesService = service;
    }

    [HttpGet]
    [Route("exercises/{id: string}")]
    public async Task<IActionResult> GetExerciseById(string id)
    {
      return await _exercisesService.GetExerciseById(id);
    }

    [HttpPost]
    [Route("bodyparts/{bodyPartName: string}/exercises")]
    public async Task<IActionResult> GetExercisesByBodyParts([FromBody] BodyPartsQueryParams? queryParams, string bodyPartName)
    {
      return await _exercisesService.GetExercisesByBodyParts(queryParams, bodyPartName);
    }

    [HttpPost]
    [Route("equipments/{equipmentName: string}/exercises")]
    public async Task<IActionResult> GetExercisesByEquipment([FromBody] EquipmentQueryParams? queryParams, string equipmentName)
    {
      return await _exercisesService.GetExercisesByEquipment(queryParams, equipmentName);
    }

    // PUT api/<Exercises>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<Exercises>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
