using API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
	public interface IApontmentService
	{
		Task<List<ApontmentDto>> GetApontmentAsync();
		Task<ApontmentDto> CreateApontmentAsync(ApontmentDto dto);
		Task DeleteApontmentAsync(int apontmentHors);
	}
}
