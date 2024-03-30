using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Views.Windows.MainWindow.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as SignInViewModel).LoginRequest.Password = (sender as PasswordBox).Password;
        }
    }
}
