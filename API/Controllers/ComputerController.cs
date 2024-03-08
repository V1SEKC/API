using API.Dto;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComputerController : ControllerBase
	{
		private readonly IComputerRepository _computerRepository;

        public ComputerController(IComputerRepository computerRepository)
        {
			_computerRepository = computerRepository;
		}

        [HttpGet]
		public async Task<ActionResult<List<ComputerDto>>> GetComputers()
		{
			List<ComputerDto> dtos = new List<ComputerDto>();
			_computerRepository.Get().ForEach(computer => dtos.Add(new ComputerDto(computer.IsFree, computer.PricePerHour, computer.Number)));
			return Ok(dtos);
		}

	}
}
