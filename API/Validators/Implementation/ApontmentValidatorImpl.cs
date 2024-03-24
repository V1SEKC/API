using API.Dto;
using API.Exceptions;
using API.Models;

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
		public void CreateApontment(ApontmentDto dto)
		{
			if (price > user.Monny)
			{
				throw new BadRequestException($"На балансе не достаточно средств");
			}
		}

		public void CreateApontmentTWO(ApontmentDto dto)
		{
			if (dto.UserId < 0 | dto.ComputerId < 0)
			{
				throw new NotFoundException($"Поле UserId и ComputerId не соответствует ожидаению");
			}	
		}
	}
}

