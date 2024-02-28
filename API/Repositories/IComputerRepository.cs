using API.Dto;
using API.Models;
using ConsoleApp1.Repositories.Base;

namespace ConsoleApp1.Repositories
{
	/// <summary>
	/// Репозиторий категорий, через него происходит взаимодействие с таблицей Computer
	/// </summary>
	public interface IComputerRepository : IBaseRepository<Computer>
	{
		/// <summary>
		/// Получение категории по номеру
		/// </summary>
		/// <param name="numer"></param>
		/// <returns></returns>
		Computer GetByNumber(string number);
	}
}