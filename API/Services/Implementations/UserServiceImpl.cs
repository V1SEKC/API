using API.Data;
using API.Dto;
using API.Exceptions;
using API.Models;
using API.Models.Base;
using API.Repositories;
using AutoMapper;
using ConsoleApp1.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Implementations
{
    public class UserServiceImpl : IUserService
	{
        private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserServiceImpl(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
			_mapper = mapper;
        }


		public async Task<List<UserDto>> GetUsersAsync()
        {
            List<UserDto> dtos = new List<UserDto>();
            List<User> users = await _userRepository.GetAsync();
			users.ForEach(user => dtos.Add(_mapper.Map<UserDto>(users)));
            return dtos;
        }

		public async Task<UserDto> DespoitAsync(DepositDto dto)
		{
			if (dto.Money <= 0 || string.IsNullOrWhiteSpace(dto.UserName))
			{
				throw new BadRequestException($"Поле Money или UserName не соответствует ожидаению");
			}
			User user = _userRepository.GetByName(dto.UserName);
			user.Monny += dto.Money;
			await _userRepository.UpdateAsync(user);
			UserDto userDto = new UserDto(_mapper.Map<UserDto>);
			return userDto;
		}

		public async Task<User> Id(int id)
		{
			return await _userRepository.GetByIdAsync(id);
		}
	}
}
