using System.Threading;
using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using API.Repositories.Implementations;
using ConsoleApp1.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetUsers()
		{
			List<UserDto> dtos = new List<UserDto>();
			_userRepository.Get().ForEach(user => dtos.Add(new UserDto(user.Monny, user.Name, user.Hors)));
			return Ok(dtos);
		}

		[HttpPut]
		public async Task<ActionResult<UserDto>> Despoit([FromBody] DepositDto dto)
		{
			if (dto.Money <= 0)
			{
				throw new BadRequestException($"Поле не соответствует ожидаению");
			}
			User user = _userRepository.GetByName(dto.UserName);
            user.Monny += dto.Money;
			_userRepository.Update(user);
			UserDto userDto = new UserDto(user.Monny, user.Name, user.Hors);
			return Ok(userDto);
		}

		public User Name(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new BadRequestException($"Поле {name} не соответствует ожидаению");
			return;
		}

	}
}
