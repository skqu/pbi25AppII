using Livecode.Service;
using Microsoft.AspNetCore.Mvc;
using Livecode.Dtos;

namespace Livecode.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;
        public UserController(UsersService service)
        {
            _usersService = service;
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] UserDto user)
        {
            _usersService.AddUser(user);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public ActionResult GetUserById(byte userId)
        {
           return Ok( _usersService.GetUser(userId));
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_usersService.GetUsers());
        }
    }
}