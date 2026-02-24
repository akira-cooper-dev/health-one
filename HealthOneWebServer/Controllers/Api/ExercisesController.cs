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
    [Route("exercises/{id}")]
    public async Task<IActionResult> GetExerciseById()
    {
      return await _exercisesService.GetExerciseById(id);
    }

    [HttpPost]
    [Route("bodyparts/{bodyPartName}/exercises")]
    public async Task<IActionResult> GetExercisesByBodyParts([FromBody]GetExerciseByBodypartsQueryParams queryParams)
    {
      return await _exercisesService.GetExercisesByBodyParts(bodyPartName, queryParams);
    }

    // POST api/<Exercises>/
    [HttpPost]
    [Route("exercises/target/{targetMuscle}")]
    public async Task<IActionResult> GetExercisesByTargetMuscle(BaseExerciseRequestQueryParams request, string targetMuscle)
    {
      return await _exercisesService.GetExercisesByTargetMuscle(request, targetMuscle);
    }

    [HttpPost]

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
