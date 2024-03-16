using API.Dto;
using API.Exceptions;
using API.Models;
using API.Services;
using ConsoleApp1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComputerController : ControllerBase
	{
		private readonly IComputerRepository _computerRepository;
		private readonly IComputerServise _computerServise;

		public ComputerController(IComputerRepository computerRepository, IComputerServise computerServise)
        {
			_computerRepository = computerRepository;
			_computerServise = computerServise;
		}

        [HttpGet]
		public async Task<ActionResult<List<ComputerDto>>> GetComputers()
		{
			return Ok(await _computerServise.GetComputersAsync());
		}

		[HttpGet]
		public async Task<ActionResult<ComputerDto>> GetComputerByNumber([FromQuery] string number)
		{
			return Ok(await _computerServise.GetComputerByNumberAsync());
		}

	}
}
