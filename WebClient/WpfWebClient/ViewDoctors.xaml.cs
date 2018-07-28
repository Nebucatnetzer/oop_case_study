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
    /// Interaction logic for ViewDoctors.xaml
    /// </summary>
    public partial class ViewDoctors : Page
    {
        public ViewDoctors()

        {
            InitializeComponent();

            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            //call method GetDoctors and save them to doctorlist

            List<WpfWebClient.ServiceReferenceEHEC.Doctor> doctorlist = new List<ServiceReferenceEHEC.Doctor>(client.GetDoctors());

            DataGridViewDoctors.ItemsSource = doctorlist;

            client.Close();
        }
    }
}
