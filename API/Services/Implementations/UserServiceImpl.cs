using API.Dto;
using API.Models;
using API.Repositories;

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
    }
}
