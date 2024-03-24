using API.Dto;
using API.Exceptions;
using API.Validators.Base;

namespace API.Validators.Implementation
{
    public class UserValidatorImpl : BaseValidator, IUserValidator
    {
        public void ValidateDeposit(DepositDto dto)
        {
            if (dto.Money <= 0 || string.IsNullOrWhiteSpace(dto.UserName))
            {
                // Скажи пользователю, какие данные необходимо прокидывать, например, поле Money должно быть больше 0
                throw new BadRequestException($"Поле {dto.Money} меньше 0 или {dto.UserName} не соответствует ожидаению");
            }
        }
    }
}
