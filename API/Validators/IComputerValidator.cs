using API.Dto;
using API.Validators.Base;
using Microsoft.AspNetCore.Mvc;

namespace API.Validators
{
	public interface IComputerValidator : IBaseValidator
	{
		//Название переделать
		void ValidatorGetComputerByNumber(string number);
	}
}
