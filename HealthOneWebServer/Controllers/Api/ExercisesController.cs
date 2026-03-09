using HealthOneWebServer.Model.ExerciseDbApi.Exercise;
using HealthOneWebServer.Services.Exercises;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    public async Task<IActionResult> GetExerciseById(string id)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(id))
        {
          return NotFound("The specified ID is invalid or empty.");
        }
        var result = await _exercisesService.GetExerciseById(id);
        if (result == null)
        {
          return NotFound($"Exercise with specified ID '{id}' was not found.");
        }
        return Ok(result);
      }
      catch (HttpRequestException ex)
      {
        if (ex.StatusCode == HttpStatusCode.NotFound)
        {
          return NotFound(ex.Message);
        }
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPost]
    [Route("bodyparts/{bodyPartName}/exercises")]
    public async Task<IActionResult> GetExercisesByBodyParts([FromBody] ExerciseRequestQueryParameters? queryParams, string bodyPartName)
    {
      try
      {
        var result = await _exercisesService.GetExercisesByBodyParts(queryParams, bodyPartName);
        if (result == null)
        {
          return NotFound($"Exercise with specified body part '{bodyPartName}' was not found.");
        }
        return Ok(result);
      }
      catch (Exception ex)
      {
        if (ex is HttpRequestException)
        {
          return NotFound(ex.Message);
        }
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("equipments/{equipmentName}/exercises")]
    public async Task<IActionResult> GetExercisesByEquipment([FromBody] ExerciseRequestQueryParameters? queryParams, string equipmentName)
    {
      try
      {
        var result = await _exercisesService.GetExercisesByEquipment(queryParams, equipmentName);
        if (result == null)
        {
          return NotFound($"Exercise with specified equipment name '{equipmentName}' was not found.");
        }
        return Ok(result);
      }
      catch (Exception ex)
      {
        if (ex is HttpRequestException)
        {
          return NotFound(ex.Message);
        }
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("muscles/{muscleName}/exercises")]
    public async Task<IActionResult> GetExercisesByMuscle([FromBody] ExerciseRequestQueryParameters? queryParams, string muscleName)
    {
      try
      {
        var result = await _exercisesService.GetExercisesByMuscle(queryParams, muscleName);
        if (result == null)
        {
          return NotFound($"Exercise with specified muscle name '{muscleName}' was not found.");
        }
        return Ok(result);
      }
      catch (Exception ex)
      {
        if (ex is HttpRequestException)
        {
          return NotFound(ex.Message);
        }
        return BadRequest(ex.Message);
      }
    }
  }
}
