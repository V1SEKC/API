using API.Dto;

namespace API.Services
{
	public interface IComputerServise
	{
		Task<List<ComputerDto>> GetComputersAsync();
		Task<ComputerDto> GetComputerByNumberAsync(string number);
	}
}
