using API.Dto;
using API.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Validators.Implementation
{
	public class ComputerValidator
	{
		public void GetComputerByNumberAsync(string number)
		{
			if (string.IsNullOrWhiteSpace(number))
			{
				throw new BadRequestException($"Поле {number} не соответствует ожидаению");
			}
		}
	}
}
