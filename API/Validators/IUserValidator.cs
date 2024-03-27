using API.Dto;
using API.Validators.Base;

namespace API.Validators
{
    public interface IUserValidator : IBaseValidator
    {
        void ValidateBalance(int price, int monny);
        void ValidateDeposit(DepositDto dto);
    }
}
