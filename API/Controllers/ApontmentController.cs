using API.Dto;
using API.Models;
using API.Repositories;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApontmentController : ControllerBase
	{
		private readonly IApontmentRepository _apontmentRepository;

		public ApontmentController(IApontmentRepository apontmentRepository)
		{
			_apontmentRepository = apontmentRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<ApontmentDto>>> GetApontment()
		{
			List<ApontmentDto> dtos = new List<ApontmentDto>();
			_apontmentRepository.Get().ForEach(apontment => dtos.Add(new ApontmentDto(apontment.beginning, apontment.enbing, apontment.hors)));
			return Ok(dtos);
		}

	}
}
