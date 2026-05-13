using Microsoft.AspNetCore.Mvc;
using Solution.Dtos;
using Solution.Services;

namespace Solution.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public ActionResult GetUser(byte userId)
        {
            UserDto? user = _userService.GetUser(userId);
            if (user == null)
            {
                return Ok("No user found");
            }
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(byte userId)
        {
            _userService.RemoveUser(userId);
            return Ok("User removed");
        }

        [HttpPost]
        public ActionResult NewUser([FromBody] UserDto user)
        {
            _userService.NewUser(user);
            return Ok(user);   
        }
    }
}