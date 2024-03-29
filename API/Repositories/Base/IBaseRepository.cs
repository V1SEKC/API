﻿using API.Models.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConsoleApp1.Repositories.Base
{
	/// <summary>
	/// Описание базовой логики для взаимодействия с любой таблицей.
	/// </summary>
	/// <typeparam name="TModel"></typeparam>
	public interface IBaseRepository<TModel> where TModel : BaseModel
	{
		/// <summary>
		/// Получение всех записей из бд
		/// </summary>
		/// <returns></returns>
		Task<List<TModel>> GetAsync();


		Task<TModel> GetByIdAsync(int id);


		/// <summary>
		/// Добавление записи в бд
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		EntityEntry<TModel> Create(TModel model);

		/// <summary>
		/// Обновление существующей записи в бд
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task UpdateAsync(TModel model);

		/// <summary>
		/// удаление записи из бд
		/// </summary>
		/// <param name="model"></param>
		void Remove(TModel model);

		/// <summary>
		/// Сохраниение изменений в бд
		/// </summary>
		Task SaveChangesAsync();
	}
}