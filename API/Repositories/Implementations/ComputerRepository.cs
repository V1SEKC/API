using API.Data;
using API.Exceptions;
using API.Models;
using ConsoleApp1.Repositories.Base;

namespace ConsoleApp1.Repositories.Implementations
{
	/// <summary>
	/// Реализация интерфейса IComputerRepository
	/// </summary>
	public class ComputerRepository : BaseRepository<Computer>, IComputerRepository
	{
		public ComputerRepository(AppDbContext context) : base(context)
		{
		}

		public Computer GetByNumber(string number)
		{
			return _context.Computer.FirstOrDefault(сomputer => сomputer.Number == number) 
				?? throw new NotFoundException($"Компьютер {number} не найден");
		}
	}
}