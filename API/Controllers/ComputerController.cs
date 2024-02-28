using System.Collections.Generic;
using API.Data;
using API.Dto;
using API.Models;
using ConsoleApp1.Repositories;
using ConsoleApp1.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
