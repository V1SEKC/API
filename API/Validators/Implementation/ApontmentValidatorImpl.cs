using API.Exceptions;

namespace API.Validators.Implementation
{
	public class ApontmentValidatorImpl
	{
		public void DeleteApontment(int apontmentHors)
		{
			if (apontmentHors <= 0)
			{
				throw new BadRequestException($"Поле не соответствует ожидаению");
			}
		}
	}
}
