using API.Dto;
using API.Repositories.ConsoleApp1.Repositories;
using ConsoleApp1.Repositories;
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
		public async Task<ActionResult<List<UserDto>>> GetUser()
		{
			List<UserDto> dtos = new List<UserDto>();
			_userRepository.Get().ForEach(user => dtos.Add(new UserDto(user.Monny, user.Name, user.Hors)));
			return Ok(dtos);
		}

	}
}
