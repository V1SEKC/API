using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Dto;
using WpfApp1.Infrastructure;
using WpfApp1.Types;

namespace WpfApp1.ViewModels
{
    public class SignInViewModel : NotifyPropertyChangedObject
    {
        private LoginRequest _loginRequest = new LoginRequest();
        private ApiConnection connection;

        public SignInViewModel()
        {
            connection = ApiConnection.GetApiConnection;
            SignInCommand = new LambdaCommand(OnSignInCommandExecuted, CanSignInCommandExecute);
            GoToSignUpPageCommand = new LambdaCommand(OnGoToSignUpPageExecuted, CanGoToSignUpPageCommandExecute);
        }

        public LoginRequest LoginRequest
        {
            get { return _loginRequest; }
            set { Set(ref _loginRequest, value); }
        }

        public ICommand GoToSignUpPageCommand { get; set; }

        public bool CanGoToSignUpPageCommandExecute(object parameter)
        {
            return true;
        }

        public void OnGoToSignUpPageExecuted(object parameter)
        {
            MainWindowNavigationViewModel.SwitchPage(MainPageType.SignUpPage);
        }

        public ICommand SignInCommand { get; set; }

        public bool CanSignInCommandExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(LoginRequest.Email) && !string.IsNullOrWhiteSpace(LoginRequest.Password);
        }

        public void OnSignInCommandExecuted(object parameter)
        {
            SignIn();
        }

        private async void SignIn()
        {
            var response = await connection.HttpClient.PostAsJsonAsync("/login", LoginRequest);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
                return;
            }
            string body = await response.Content.ReadAsStringAsync();
            SignInEntity user = JsonConvert.DeserializeObject<SignInEntity>(body);
            connection.HttpClient.DefaultRequestHeaders.Add("Authorization", $"{user.TokenType} {user.AccessToken}");
            connection.RefreshToken = user.RefreshToken;
            MainWindowNavigationViewModel.SwitchPage(MainPageType.ComputerPage);
        }
    }
}
