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
    /// Interaction logic for NoAccountWindow.xaml
    /// </summary>
    public partial class NoAccountWindow : Window
    {
        public NoAccountWindow()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            StartUp startWindow = new StartUp();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
        }
    }
}
