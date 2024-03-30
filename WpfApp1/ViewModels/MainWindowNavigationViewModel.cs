using System.ComponentModel;
using System;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using WpfApp1.Views.Windows.MainWindow.Pages;
using WpfApp1.Types;

namespace WpfApp1.ViewModels
{
    public class MainWindowNavigationViewModel
    {
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        
        private static Page selectedPage;
        private static SignInPage signInPage;
        private static SignUpPage signUpPage;
        private static ComputerPage computerPage;

        public MainWindowNavigationViewModel()
        {
            SwitchPage(MainPageType.SignInPage);
        }

        public static Page SelectedPage
        {
            get { return selectedPage; }
            set { Set(ref selectedPage, value); }
        }

        public static void SwitchPage(MainPageType mainPageType)
        {
            switch (mainPageType)
            { 
                case MainPageType.SignInPage:
                    signInPage ??= new SignInPage();
                    SelectedPage = signInPage;
                    break;
                case MainPageType.SignUpPage:
                    signUpPage ??= new SignUpPage();
                    SelectedPage = signUpPage;
                    break;
                case MainPageType.ComputerPage:
                    computerPage ??= new ComputerPage();
                    SelectedPage = computerPage;
                    break;
            }
        }

        public static void OnPropertyChanged([CallerMemberName] string propetyName = null) => StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propetyName));

        public static bool Set<T>(ref T field, T value, [CallerMemberName] string propetyName = null)
        {
            if (Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propetyName);
            return true;
        }
    }
}
