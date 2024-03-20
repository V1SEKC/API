using API.Data;
using ConsoleApp1.Repositories.Base;
using API.Models;
using API.Exceptions;

namespace API.Repositories.Implementations
{
		/// <summary>
		/// Реализация интерфейса IComputerRepository
		/// </summary>
		public class UserRepository : BaseRepository<User>, IUserRepository
		{
			public UserRepository(AppDbContext context) : base(context)
			{
			}

			public User GetByName(string name)
			{
				return _context.User.FirstOrDefault(user => user.Name == name) 
				?? throw new NotFoundException($"Пользователь {name} не найден");
			}
	}
}
