using System.Windows;
using System.Windows.Navigation;

namespace WpfApp1.Views.Windows.MainWindow
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            e.Cancel = e.NavigationMode != NavigationMode.New;
        }
    }
}
