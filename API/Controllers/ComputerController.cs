using API.Dto;
using API.Exceptions;
using API.Models;
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
			List<Computer> computers = await _computerRepository.GetAsync();
			computers.ForEach(computer => dtos.Add(new ComputerDto(computer.IsFree, computer.PricePerHour, computer.Number)));
			return Ok(dtos);
		}

		[HttpGet]
		public async Task<ActionResult<ComputerDto>> GetComputerByNumber([FromQuery] string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				throw new BadRequestException($"Поле {number} не соответствует ожидаению");
			}
			Computer computer = _computerRepository.GetByNumber(number);

			return Ok(new ComputerDto(computer.IsFree, computer.PricePerHour, computer.Number)); 
		}

	}
}
