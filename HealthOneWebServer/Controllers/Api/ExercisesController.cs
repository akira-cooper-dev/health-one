using Microsoft.AspNetCore.Mvc;
using HealthOneWebServer.Model.RapidAPI.Exercises;
using HealthOneWebServer.Services.Exercises;

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
    // GET: api/<Exercises>
    [HttpGet]
    public IEnumerable<string> GetExercise()
    {
      return new string[] { "value1", "value2" };
    }

    // POST api/<Exercises>/
    [HttpPost]
    [Route("exercises/target/{targetMuscle}")]
    public async Task<IActionResult> GetExercisesByTargetMuscle(BaseExerciseRequestQueryParams request, string targetMuscle)
    {
      return await _exercisesService.GetExercisesByTargetMuscle(request, targetMuscle);
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
