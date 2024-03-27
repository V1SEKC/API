using API.Dto;
using API.Exceptions;
using API.Validators.Base;

namespace API.Validators.Implementation
{
	public class ApontmentValidatorImpl : BaseValidator, IApontmentValidator
	{
		public void ValidateApontmentHors(int apontmentHors)
		{
			if (apontmentHors > 0)
			{
				//Привести сообщение к более понятному виду
				throw new BadRequestException($"Поле не соответствует ожидаению");
			}
		}
		public void ValidateApontmentDto(ApontmentDto dto)
		{
			if (dto.Hors > 0 && dto.Ending < DateTime.Now)
			{
                //Привести сообщение к более понятному виду
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

