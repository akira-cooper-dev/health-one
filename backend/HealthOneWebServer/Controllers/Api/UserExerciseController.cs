using HealthOneWebServer.Model.Dto.Exercise;
using HealthOneWebServer.Model.Dto.UserExercise;
using HealthOneWebServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthOneWebServer.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExerciseController : Controller
    {
        private readonly UserExerciseService _userExerciseService;

        public UserExerciseController(UserExerciseService userExerciseService)
        {
            _userExerciseService = userExerciseService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<ExerciseDto>> GetAllExercisesByUserId(int userId)
        {
            try
            {
                var result = await _userExerciseService.GetAllExercisesByUserId(userId);
                if (result == null)
                {
                    return NotFound($"No exercises found for user with ID '{userId}'.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDto>> AddUserExercise([FromBody] CreateUserExerciseRequestDto dto)
        {
            try
            {
                var result = await _userExerciseService.AddUserExercise(dto);
                if (result == null)
                {
                    return NotFound($"Failed to add user exercise.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
