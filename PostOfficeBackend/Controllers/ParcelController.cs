using Microsoft.AspNetCore.Mvc;
using PostOfficeBackend.Dtos;
using PostOfficeBackend.Services;
using System.Threading.Tasks;

namespace PostOfficeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelService _parcelService;

        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() =>
            Ok(await _parcelService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            return Ok(parcel);
        }

        [HttpGet]
        [Route("ParcelsbyPost/{postId}")]
        public async Task<ActionResult> GetByPostId(int postId)
        {
            var better = await _parcelService.GetByPostIdAsync(postId);
            return Ok(better);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParcelCreateEditDto parcel)
        {
            var result = await _parcelService.CreateAsync(parcel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _parcelService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ParcelCreateEditDto parcel)
        {
            await _parcelService.UpdateAsync(parcel);
            return NoContent();
        }
    }
}
