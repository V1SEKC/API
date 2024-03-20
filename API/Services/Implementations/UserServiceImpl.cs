using API.Dto;
using API.Models;
using API.Repositories;
using API.Validators;
using AutoMapper;

namespace API.Services.Implementations
{
    public class UserServiceImpl : IUserService
	{
        private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly IUserValidator _userValidator;

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
			_userValidator.ValidateDeposit(dto);
			User user = _userRepository.GetByName(dto.UserName);
			user.Monny += dto.Money;
			await _userRepository.UpdateAsync(user);
			return _mapper.Map<UserDto>(user);
		}

		//Переименовать и изменить возвращаемый тип данных на UserDto
		public async Task<User> Id(int id)
		{
			_userValidator.ValidateId(id);
			return await _userRepository.GetByIdAsync(id);
		}
	}
}
