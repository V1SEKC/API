using API.Exceptions;

namespace API.Validators.Implementation
{
	public class ComputerValidator
	{
		public void GetComputerByNumberAsync(string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				throw new BadRequestException($"Поле {number} не соответствует ожидаению");
			}
		}
	}
}
