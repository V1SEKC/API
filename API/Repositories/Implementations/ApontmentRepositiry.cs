using API.Data;
using ConsoleApp1.Repositories.Base;
using ConsoleApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Repositories.Implementations
{
	public class ApontmentRepository : BaseRepository<Apontment>, IApontmentRepository
	{
		public ApontmentRepository(AppDbContext context) : base(context)
		{
		}

		public Apontment GetByHors(int hors)
		{
			return _context.Apontment.FirstOrDefault(apontment => apontment.Hors == hors);
		}
	}
}
