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
           

            //Retrieve all salutations and save them into "salutationlist"
            List<WpfWebClient.ServiceReferenceEHEC.Salutation> salutationlist = new List<ServiceReferenceEHEC.Salutation>(client.GetSalutations());

            //Display all salutations with name in Combobox
            ComboBoxSalutations.ItemsSource = salutationlist;
            ComboBoxSalutations.DisplayMemberPath = "Name";

            //Retrieve all cities and save them into "citylist"
            List<WpfWebClient.ServiceReferenceEHEC.City> citylist = new List<ServiceReferenceEHEC.City>(client.GetCities());

            //Display all cities with name in Combobox
            ComboBoxCities.ItemsSource = citylist;
            ComboBoxCities.DisplayMemberPath = "Name";

            //Retrieve all salutations and save them into "countrylist"
            List<WpfWebClient.ServiceReferenceEHEC.Country> countrylist = new List<ServiceReferenceEHEC.Country>(client.GetCountries());

            //Display all countries with name in Combobox
            ComboBoxCountries.ItemsSource = countrylist;
            ComboBoxCountries.DisplayMemberPath = "Name";

            //Retrieve all doctors and save them into "doctorlist"
            List<WpfWebClient.ServiceReferenceEHEC.Doctor> doctorlist = new List<ServiceReferenceEHEC.Doctor>(client.GetDoctors());
            

            //Display all doctors with name in Combobox
            ComboBoxDoctors.ItemsSource = doctorlist;
            ComboBoxDoctors.DisplayMemberPath = "FirstName";




        }
    }
}
