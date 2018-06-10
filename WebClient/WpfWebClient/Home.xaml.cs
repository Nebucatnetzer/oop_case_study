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
using WpfWebClient.ServiceReferenceEHEC;

namespace WpfWebClient
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click_GeneratePatients(object sender, RoutedEventArgs e)
        {

            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();
            Person p = new Person();

            //p.City = 1;
            p.FirstName = "Lucas";
            p.LastName = "Meier";
            p.StreetName = "Hansestrasse";
            //p.Salutation = 1;
            //p.Gender = 1;



            // Patient an Webservice übermitteln
            client.WritePatient(p);

            // Client schliessen
            client.Close();
        }
    }
}
