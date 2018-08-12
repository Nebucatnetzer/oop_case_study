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
    /// Interaction logic for ViewCases.xaml
    /// </summary>
    public partial class ViewStrains : Page
    {
        public ViewStrains()
        {
            InitializeComponent();

            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            // call method GetStrains and save them to strainlist

            List<WpfWebClient.ServiceReferenceEHEC.Strain> strainlist = new List<ServiceReferenceEHEC.Strain>(client.GetStrains());

            DataGridViewStrains.ItemsSource = strainlist;
            

            client.Close();
        }

    }
}
