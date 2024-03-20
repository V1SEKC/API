using API.Dto;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApontmentController : ControllerBase
	{
		private readonly IApontmentService _apontmentService;

		public ApontmentController(IApontmentService apontmentService)
		{
			_apontmentService = apontmentService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ApontmentDto>>> GetApontment()
		{
			return Ok(await _apontmentService.GetApontmentAsync());
		}

        [HttpPost]
        public async Task<ActionResult<ApontmentDto>> CreateApontment([FromBody] ApontmentDto dto)
        {
			return Ok(await _apontmentService.GetApontmentAsync());
		}

        [HttpDelete("{ApontmentHors}")]
        public async Task<ActionResult> DeleteApontment([FromRoute] int apontmentHors)
        {
			await _apontmentService.DeleteApontmentAsync(apontmentHors);
            return Ok();
		}
	}
}
