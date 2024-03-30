using System.Collections.Generic;
using Newtonsoft.Json;
using WpfApp1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Infrastructure;

namespace WpfApp1.ViewModels
{
	public class ViewModel : NotifyPropertyChangedObject
	{
		private ObservableCollection<Computer> _computers;
		private readonly ApiConnection apiConnection;

        public ViewModel()
        {
			apiConnection = ApiConnection.GetApiConnection;
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
			var response = await apiConnection.HttpClient.GetAsync("/api/Computer");
			if (!response.IsSuccessStatusCode)
				return;
			string body = await response.Content.ReadAsStringAsync();
			Computers = new ObservableCollection<Computer>(JsonConvert.DeserializeObject<List<Computer>>(body));
		}
	}
}
