using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseFilter;
using HealthOneWebServer.Model.Dto.AscendApi.ExerciseDbV1Api.ExerciseSearch;
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

        #region Endpoints for external ExerciseDbV1Api calls
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
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetExercisesBySearch([FromBody] ExerciseSearchRequestDto request)
        {
            try
            {
                var result = await _exercisesService.GetExercisesBySearchWithFuzzyMatching(request);
                if (result == null)
                {
                    return NotFound("No exercises found.");
                }
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest(ex.Message);
                }
                else if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> GetExercisesByAdvancedFiltering([FromBody] ExerciseFilterRequestDto request)
        {
            try
            {
                var result = await _exercisesService.GetExercisesByAdvancedFiltering(request);
                if (result == null)
                {
                    return NotFound("No exercises found.");
                }
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest(ex.Message);
                }
                else if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
