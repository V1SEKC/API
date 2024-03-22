using API.Validators.Base;

namespace API.Validators
{
	public interface IApontmentValidator : IBaseValidator
	{
		//Переделать название
		void ValidatorDeleteApontment(int apontmentHors);
	}
}
