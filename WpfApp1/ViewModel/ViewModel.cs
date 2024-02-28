﻿using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using WpfApp1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Infrastructure;

namespace WpfApp1.ViewModel
{
	public class ViewModel : NotifyPropertyChangedObject
	{
		private ObservableCollection<Computer> _computers;

		private HttpClient httpClient = new HttpClient();

        public ViewModel()
        {
			RefreshCommand = new LambdaCommand(OnRefreshCommandExecuted, CanRefreshCommandExecute);
			
			LoadData();
        }

		public ObservableCollection<Computer> Computers
		{
			get { return _computers; }
			set { Set(ref _computers, value); } 
		}


		public ICommand RefreshCommand { get; set; }

		public bool CanRefreshCommandExecute(object parametr)
		{
			return true;
		}

		public void OnRefreshCommandExecuted(object parametr)
		{
			LoadData();
		}

		private async void LoadData()
		{
			var response = await httpClient.GetAsync("https://localhost:7041/api/Computer");
			if (!response.IsSuccessStatusCode) //Если не усешно
				return;
			string body = await response.Content.ReadAsStringAsync(); //Считали контенкт как строку

			Computers = new ObservableCollection<Computer>(JsonConvert.DeserializeObject<List<Computer>>(body));

			

			//Сущность User, Apontment-запись соединяет таблицу юзер и таблицу пк есть время начала и время конца, Многие ко многим.
			// В контролере будет пост метод, который отвечает за создание записи, новый контролер. Еще раз миграции 
			// Еще один репозиторий для зависимости 



		}
	}
}
