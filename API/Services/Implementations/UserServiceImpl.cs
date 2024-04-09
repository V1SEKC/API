using API.Dto;
using API.Exceptions;
using API.Models;
using API.Repositories;
using API.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementations
{
    public class UserServiceImpl : IUserService
	{
        private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IUserValidator _userValidator;

		//Добавил зависимость, но не инициализируешь в констркторе
		public UserServiceImpl(UserManager<User> userManager, IMapper mapper, IUserValidator userValidator)
        {
            _userManager = userManager;
			_mapper = mapper;
			_userValidator = userValidator;
		}

		public async Task<List<UserDto>> GetUsersAsync()
        {
            List<UserDto> dtos = new List<UserDto>();
            List<User> users = await _userManager.Users.ToListAsync();
			users.ForEach(user => dtos.Add(_mapper.Map<UserDto>(users)));
            return dtos;
        }

		public async Task<UserDto> DespoitAsync(DepositDto dto)
		{
			_userValidator.ValidateDeposit(dto);
			User user = await _userManager.FindByNameAsync(dto.UserName) 
				?? throw new NotFoundException($"Нет пользователя с именем {dto.UserName}");
			user.Monny += dto.Money;
			await _userManager.UpdateAsync(user);
			return _mapper.Map<UserDto>(user);
		}

		public async Task<UserDto> GetUserByIdAsync(int id)
		{
			_userValidator.ValidateId(id);
			return _mapper.Map<UserDto>(await _userManager.FindByIdAsync(id.ToString()));
		}
	}
}
