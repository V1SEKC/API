using API.Dto;

namespace API.Services
{
	public interface IApontmentService
	{
		Task<List<ApontmentDto>> GetApontmentAsync();
		Task<ApontmentDto> CreateApontmentAsync(ApontmentDto dto);
		Task DeleteApontmentAsync(int apontmentHors);
	}
}
