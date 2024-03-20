using API.Dto;

namespace API.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> DespoitAsync(DepositDto dto);

	}
}
