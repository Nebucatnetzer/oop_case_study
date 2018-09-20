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

            client.Close();
        }

        private void btnAddFoodPlace_Click(object sender, RoutedEventArgs e)
        {
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

                // create new foodplace from user input

                FoodPlace fp = new FoodPlace();

            // check if any box is empty

            if (ComboBoxFPCities.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Please select a city", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (txtFoodPlaceName.Text == null)
            {
                System.Windows.MessageBox.Show("Please enter a name for the food place", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (txtFoodPlaceHouseNumber.Text == null)
            {
                System.Windows.MessageBox.Show("Please enter a house number", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (txtFoodPlaceStreetName.Text == null)
            {
                System.Windows.MessageBox.Show("Please enter a street name", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                fp.Streetname = txtFoodPlaceStreetName.Text;
                fp.Streetnumber = txtFoodPlaceHouseNumber.Text;
                fp.Name = txtFoodPlaceName.Text;
                fp.Description = txtFoodPlaceDescription.Text;
                fp.City = (City)ComboBoxFPCities.SelectedValue;

                client.WriteFoodPlace(fp);

                // Show success msgbox
                System.Windows.MessageBox.Show("Success", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            client.Close();
        }
    }
}
