using API.Data;
using API.Exceptions;
using API.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConsoleApp1.Repositories.Base
{
	/// <summary>
	/// Реализация базовой логики для взаимодействия с любой таблицей.
	/// </summary>
	/// <typeparam name="TModel"></typeparam>
	public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
	{
		protected readonly AppDbContext _context;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
		}

		public EntityEntry<TModel> Create(TModel model)
		{
			return _context.Set<TModel>().Add(model);
		}

		public void Remove(TModel model)
		{
			_context.Set<TModel>().Remove(model);
		}

		public async Task<List<TModel>> GetAsync()
		{
			return await _context.Set<TModel>().ToListAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(TModel model)
		{
			_context.Set<TModel>().Update(model);
			await _context.SaveChangesAsync();
		}

		public async Task<TModel> GetByIdAsync(int id)
		{
			return await _context.Set<TModel>().FindAsync(id) ?? throw new NotFoundException($"Элемент с id {id} не найден");
		}
	}
}