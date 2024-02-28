using API.Models;
using ConsoleApp1.Repositories.Base;

namespace API.Repositories
{
		public interface IApontmentRepository : IBaseRepository<Apontment>
		{
			/// <summary>
			/// Получение категории по номеру
			/// </summary>
			/// <param name="hors"></param>
			/// <returns></returns>
			Apontment GetByHors(int hors);
		}
}
