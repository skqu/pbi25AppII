using Microsoft.AspNetCore.Mvc;
using Code.Dtos;
using Code.Services;

namespace Code.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService src)
        {
            _postService = src;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, Post>> AllPost()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpPost] // Creating a new post
        public ActionResult AddPost([FromBody] Post post)
        {
            _postService.AddPost(post);
            return CreatedAtAction(nameof(AllPost), post);
        }

        [HttpPut("{id}")] // Update existing post
        public ActionResult UpdatePost(int id, [FromBody] Post post)
        {
            _postService.UpdatePost(id.ToString(), post);
            return Ok(post);
        
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePost(int id)
        {
            _postService.DeletePost(id.ToString());
            return Ok();
        }
    }
}