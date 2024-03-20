using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetUsers()
		{
			return Ok(await _userService.GetUsersAsync());
		}

		[HttpPut]
		public async Task<ActionResult<UserDto>> Despoit([FromBody] DepositDto dto)
		{
			return Ok(await _userService.DespoitAsync(dto));
		}
	}
}
