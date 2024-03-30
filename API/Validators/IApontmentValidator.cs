using API.Dto;
using API.Validators.Base;

namespace API.Validators
{
	public interface IApontmentValidator : IBaseValidator
	{
		void ValidateApontmentHors(int apontmentHors);
		void ValidateApontmentDto(ApontmentDto dto);
	}
}
