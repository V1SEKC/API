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
		private readonly IUserRepository _userRepository;
		private readonly IUserService _userService;

		public UserController(IUserRepository userRepository, IUserService userService)
		{
			_userRepository = userRepository;
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
			if (dto.Money <= 0 || string.IsNullOrWhiteSpace(dto.UserName))
			{
				throw new BadRequestException($"Поле Money или UserName не соответствует ожидаению");
			}
			User user = _userRepository.GetByName(dto.UserName);
            user.Monny += dto.Money;
			_userRepository.UpdateAsync(user);
			UserDto userDto = new UserDto(user.Monny, user.Name, user.Hors);
			return Ok(userDto);
		}
	}
}
