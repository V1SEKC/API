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
		private readonly IComputerServise _computerServise;

        public ComputerController(IComputerServise computerServise)
        {
			_computerServise = computerServise;
		}

		[HttpGet]
		public async Task<ActionResult<List<ComputerDto>>> GetComputers()
		{
			return Ok(await _computerServise.GetComputersAsync());
		}

		[HttpGet("{number}")]
		public async Task<ActionResult<ComputerDto>> GetComputerByNumber([FromRoute] string number)
		{
			return Ok(await _computerServise.GetComputerByNumberAsync(number));
		}

	}
}
