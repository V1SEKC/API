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
    public class SignUpViewModel : NotifyPropertyChangedObject
    {
        private LoginRequest _loginRequest;
        private ApiConnection connection;

        public SignUpViewModel()
        {
            LoginRequest = new LoginRequest();
            connection = ApiConnection.GetApiConnection;
            GoToSignInPageCommand = new LambdaCommand(OnGoToSignUpPageExecuted, CanGoToSignUpPageCommandExecute);
            SignUpCommand = new LambdaCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }

        public LoginRequest LoginRequest
        {
            get { return _loginRequest; }
            set { Set(ref _loginRequest, value); }
        }

        public ICommand GoToSignInPageCommand { get; set; }

        public bool CanGoToSignUpPageCommandExecute(object parameter)
        {
            return true;
        }

        public void OnGoToSignUpPageExecuted(object parameter)
        {
            MainWindowNavigationViewModel.SwitchPage(MainPageType.SignInPage);
        }

        public ICommand SignUpCommand { get; set; }

        public bool CanSignUpCommandExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(LoginRequest.Email) && !string.IsNullOrWhiteSpace(LoginRequest.Password);
        }

        public void OnSignUpCommandExecuted(object parameter)
        {
            SignUp();
        }

        private async void SignUp()
        {
            var response = await connection.HttpClient.PostAsJsonAsync("/register", LoginRequest);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
                return;
            }
            SignIn();
            MainWindowNavigationViewModel.SwitchPage(MainPageType.ComputerPage);
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
