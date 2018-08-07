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
    /// Interaction logic for FoodplaceForm.xaml
    /// </summary>
    public partial class FoodplaceForm : Page
    {
        public FoodplaceForm()
        {
            InitializeComponent();

            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            // Retrieve all cities and save them into "citylist"
            List<WpfWebClient.ServiceReferenceEHEC.City> citylist = new List<ServiceReferenceEHEC.City>(client.GetCities());

            // Display all cities with name in Combobox
            ComboBoxFPCities.ItemsSource = citylist;
            ComboBoxFPCities.DisplayMemberPath = "Name";
        }

        private void btnAddFoodPlace_Click(object sender, RoutedEventArgs e)
        {
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            // create new foodplace from user input

            FoodPlace fp = new FoodPlace();

            fp.Name = txtFoodPlaceName.Text;
            fp.Streetname = txtFoodPlaceStreetName.Text;
            fp.Streetnumber = txtFoodPlaceHouseNumber.Text;
            fp.Description = txtFoodPlaceDescription.Text;
            fp.City = (City)ComboBoxFPCities.SelectedValue;

            client.WriteFoodPlace(fp);

            client.Close();
        }
    }
}
