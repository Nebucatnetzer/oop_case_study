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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWebClient
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

        private void Button_Click_NewCase(object sender, RoutedEventArgs e)
        {
            Main.Content = new PatientForm();
        }

        private void Button_Click_ViewDoctors(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewDoctors();
        }

        private void Button_Click_ViewStrains(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewStrains();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            Main.Content = new Home();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
