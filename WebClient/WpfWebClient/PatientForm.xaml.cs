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
    /// Interaction logic for PatientForm.xaml
    /// </summary>
    public partial class PatientForm : Page
    {
        public PatientForm()
        {
            InitializeComponent();
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            Person p = new Person();

            p.FirstName = txtVorname.ToString();
            p.LastName = txtName.ToString();
            p.StreetName = txtStrasse.ToString();



            client.WritePatient(p);


            // Client Verbindung schliessen
            client.Close();
        }
    }
}
