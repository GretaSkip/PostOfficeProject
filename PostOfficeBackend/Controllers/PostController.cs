using Microsoft.AspNetCore.Mvc;
using PostOfficeBackend.Entities;
using PostOfficeBackend.Services;
using System.Threading.Tasks;

namespace PostOfficeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() =>
            Ok(await _postService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Post post)
        {
            var result = await _postService.CreateAsync(post);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Post post)
        {
            await _postService.UpdateAsync(post);
            return NoContent();
        }
    }
}
