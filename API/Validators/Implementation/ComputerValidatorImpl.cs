using API.Exceptions;
using API.Validators.Base;

namespace API.Validators.Implementation
{
	public class ComputerValidatorImpl : BaseValidator, IComputerValidator
	{
		public void ValidateComputerNumber(string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				throw new BadRequestException($"Поле {number} не соответствует ожидаению");
			}
		}
    }
}
