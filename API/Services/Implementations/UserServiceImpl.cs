using API.Dto;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Implementations
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            List<UserDto> dtos = new List<UserDto>();
            List<User> users = await _userRepository.GetAsync();
            users.ForEach(user => dtos.Add(new UserDto(user.Monny, user.Name, user.Hors)));
            return dtos;
        }

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
