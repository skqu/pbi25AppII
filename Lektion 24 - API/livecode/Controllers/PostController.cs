using Microsoft.AspNetCore.Mvc;
using Livecode.Dtos;
using Livecode.Services;

namespace Livecode.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private UserService _userService; 
        public PostController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<Post[]> GetPosts()
        {
            return Ok(_userService.AllPosts());
        }

        [HttpPost]
        public ActionResult<Post> AddPost([FromBody] Post post)
        {
            _userService.AddPost(post);
            return Ok(post);
        }

    }
}