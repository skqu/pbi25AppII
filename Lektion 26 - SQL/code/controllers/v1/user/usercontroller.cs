using Microsoft.AspNetCore.Mvc;
using code.dto;
using code.services.user;

namespace code.controllers.v1.user
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser([FromBody] UserDto user)
        {
            UserDto newUser = await _userService.CreateUserAsync(user);
            return Ok(newUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            UserDto? user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}