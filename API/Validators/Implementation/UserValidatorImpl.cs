using API.Dto;
using API.Exceptions;
using API.Validators.Base;

namespace API.Validators.Implementation
{
    public class UserValidatorImpl : BaseValidator, IUserValidator
    {
        public void ValidateBalance(int price, int monny)
        {
            if (price > monny)
            {
                //Добавить сообщение
                throw new BadRequestException($"");
            }
        }

        public void ValidateDeposit(DepositDto dto)
        {
            if (dto.Money <= 0 || string.IsNullOrWhiteSpace(dto.UserName))
            {
                throw new BadRequestException($"Поле {dto.Money} меньше 0 или {dto.UserName} не соответствует ожидаению");
            }
        }
    }
}
