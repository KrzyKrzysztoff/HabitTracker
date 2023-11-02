using HabitTrackerAPI.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace HabitTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            return Ok();
        }
    }
}
