using API.Data;
using ConsoleApp1.Repositories.Base;
using ConsoleApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories.ConsoleApp1.Repositories;

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
				return _context.User.FirstOrDefault(user => user.Name == name);
			}
		}
}
