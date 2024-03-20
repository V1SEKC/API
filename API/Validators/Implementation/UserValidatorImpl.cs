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
                throw new BadRequestException($"Поле Money или UserName не соответствует ожидаению");
            }
        }
    }
}
