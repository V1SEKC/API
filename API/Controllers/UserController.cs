using API.Dto;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

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
				// TO DO выполнить обработку случая
			}
			User user = _userRepository.GetByName(dto.UserName);
            user.Monny += dto.Money;
			_userRepository.Update(user);
			UserDto userDto = new UserDto(user.Monny, user.Name, user.Hors);
			return Ok(userDto);
		}
	}
}
