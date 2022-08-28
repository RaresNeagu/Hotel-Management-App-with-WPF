using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for StartUp.xaml
    /// </summary>
    public partial class StartUp : Window
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            SignIn signInWindow = new SignIn();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = signInWindow;
            App.Current.MainWindow.Show();
        }

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            SignUp signUpWindow = new SignUp();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = signUpWindow;
            App.Current.MainWindow.Show();
        }

        private void NoAccountClick(object sender, RoutedEventArgs e)
        {
            NoAccountWindow noAccountWindow = new NoAccountWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = noAccountWindow;
            App.Current.MainWindow.Show();
        }
    }
}
