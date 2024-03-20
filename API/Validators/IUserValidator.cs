using API.Dto;
using API.Validators.Base;

namespace API.Validators
{
    public interface IUserValidator : IBaseValidator
    {
        void ValidateDeposit(DepositDto dto);
    }
}
