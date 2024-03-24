using API.Dto;
using API.Models;
using API.Validators.Base;

namespace API.Validators
{
	public interface IApontmentValidator : IBaseValidator
	{
		//Переделать название
		void ValidatorDeleteApontment(int apontmentHors);
		void ValidatorCreateApontment(ApontmentDto dto);
		void ValidatorCreateApontmentTWO(ApontmentDto dto);
	}
}
