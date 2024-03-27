using API.Validators.Base;

namespace API.Validators
{
	public interface IComputerValidator : IBaseValidator
	{
		void ValidateComputerNumber(string number);
	}
}
