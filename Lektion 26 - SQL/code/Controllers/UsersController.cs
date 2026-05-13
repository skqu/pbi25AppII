using Microsoft.AspNetCore.Mvc;
using Code.Dtos;
using Code.Services;
namespace Code.Controllers
{
    [ApiController]
    [Route("users/")]
    public class UsersController : ControllerBase
    {
        UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult NewUser([FromBody] UsersDto user)
        {
            _userService.NewUser(user);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public ActionResult GetUser(byte userId)
        {
            UsersDto? user = _userService.GetUser(userId);
            if (user == null)
            {
                return Ok("User does not exist");
            }
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(byte userId)
        {
            _userService.Remove(userId);
            return Ok("User removed");
        }


    }
}