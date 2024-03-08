﻿using API.Data;
using API.Models.Base;
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

		public List<TModel> Get()
		{
			return _context.Set<TModel>().ToList();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(TModel model)
		{
			_context.Set<TModel>().Update(model);
			_context.SaveChanges();
		}

		public TModel GetById(int id)
		{
			return _context.Set<TModel>().Find(id);
		}
	}
}