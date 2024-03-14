using API.Data;
using ConsoleApp1.Repositories.Base;
using API.Models;
using API.Exceptions;

namespace API.Repositories.Implementations
{
	public class ApontmentRepository : BaseRepository<Apontment>, IApontmentRepository
	{
		public ApontmentRepository(AppDbContext context) : base(context)
		{
		}

		public Apontment GetByHors(int hors)
		{
            return _context.Apontment.FirstOrDefault(apontment => apontment.Hors == hors) 
				?? throw new NotFoundException($"Заявка на {hors} часов не найдена");
        }
    }
}
