using API.Models;
using ConsoleApp1.Repositories.Base;

namespace API.Repositories
{
	/// <summary>
	/// Репозиторий категорий, через него происходит взаимодействие с таблицей User
	/// </summary>
	public interface IUserRepository : IBaseRepository<User>
	{
		/// <summary>
		/// Получение категории по номеру
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		User GetByName(string Name);
	}
}
