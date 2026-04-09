using HealthOneWebServer.Model.Dto.ExerciseDbV1Api;
using HealthOneWebServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthOneWebServer.Controllers.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly ExerciseService _exercisesService;

        public ExerciseController(ExerciseService service)
        {
            _exercisesService = service;
        }

        #region ExerciseDbApi
        [HttpGet]
        [Route("{id}")]
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
        [Route("bodypart/{bodyPartName}")]
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
        [Route("equipment/{equipmentName}")]
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
        [Route("muscle/{muscleName}")]
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

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetExercisesByFuzzyMatching([FromBody] ExerciseRequestQueryParameters? queryParams)
        {
            try
            {
                var result = await _exercisesService.GetExercisesByFuzzyMatching(queryParams);
                if (result == null)
                {
                    return NotFound("No exercises found matching the specified search criteria.");
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
        [Route("optional-search")]
        public async Task<IActionResult> GetExercisesByOptionalSearch([FromBody] ExerciseRequestQueryParameters? queryParams)
        {
            try
            {
                var result = await _exercisesService.GetExercisesByOptionalSearch(queryParams);
                if (result == null)
                {
                    return NotFound("No exercises found matching the specified search criteria.");
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
        [Route("filter")]
        public async Task<IActionResult> GetExercisesByAdvancedFiltering([FromBody] ExerciseRequestQueryParameters? queryParams)
        {
            try
            {
                var result = await _exercisesService.GetExercisesByAdvancedFiltering(queryParams);
                if (result == null)
                {
                    return NotFound("No exercises found matching the specified search criteria.");
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
        #endregion

        #region Database
        //[HttpPost]
        //public async Task<IActionResult> AddExercise([FromBody] ExerciseDto exercise)
        //{
        //    try
        //    {
        //        var result = await _exercisesService.AddExercise(exercise);
        //        if (result == null)
        //        {
        //            return BadRequest("Failed to add the exercise. Please check the provided data.");
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        #endregion
    }
}
