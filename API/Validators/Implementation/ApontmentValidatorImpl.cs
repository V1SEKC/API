using API.Dto;
using API.Exceptions;
using API.Validators.Base;

namespace API.Validators.Implementation
{
	public class ApontmentValidatorImpl : BaseValidator, IApontmentValidator
	{
		public void ValidateApontmentHors(int apontmentHors)
		{
			if (apontmentHors < 0)
			{
				//Привести сообщение к более понятному виду
				throw new BadRequestException($"Поле {apontmentHors} меньше 0, добавте больше часов");
			}
		}
		public void ValidateApontmentDto(ApontmentDto dto)
		{
			if (dto.Hors < 0 && dto.Ending < DateTime.Now)
			{
                //Привести сообщение к более понятному виду
                throw new BadRequestException($"Поле {dto.Hors} меньше 0, либо же ваше время окончания настенет раньше текущего");
			}
		}
	}
}

