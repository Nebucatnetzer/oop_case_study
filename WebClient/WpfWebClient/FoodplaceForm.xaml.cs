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
        }

        private void btnAddFoodPlace_Click(object sender, RoutedEventArgs e)
        {
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            FoodPlace fp = new FoodPlace();

            fp.Name = txtFoodPlaceName.ToString();
            fp.Streetname = txtFoodPlaceStreetName.ToString();
            fp.Streetnumber = txtFoodPlaceHouseNumber.ToString();
            fp.Description = txtFoodPlaceDescription.ToString();

            client.WriteFoodPlace(fp);

            client.Close();
        }
    }
}
