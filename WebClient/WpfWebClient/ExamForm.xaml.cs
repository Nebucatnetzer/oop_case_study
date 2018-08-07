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
    /// Interaction logic for CaseForm.xaml
    /// </summary>
    public partial class ExamForm : Page
    {
        public ExamForm()
        {
            InitializeComponent();
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();


            //Retrieve all doctors and save them into "doctorlist"
            List<WpfWebClient.ServiceReferenceEHEC.Doctor> doctorlist = new List<ServiceReferenceEHEC.Doctor>(client.GetDoctors());

            //Display all doctors with name in Combobox
            ComboBoxDoctors.ItemsSource = doctorlist;
            ComboBoxDoctors.DisplayMemberPath = "FirstName";

            //Retrieve all patients and save them into "patientlist"
            List<WpfWebClient.ServiceReferenceEHEC.Person> patientlist = new List<ServiceReferenceEHEC.Person>(client.GetPersons());

            //Display all patients with name in Combobox
            ComboBoxPatients.ItemsSource = patientlist;
            ComboBoxPatients.DisplayMemberPath = "FirstName";

            //Retrieve all strains and save them into "strainlist"
            List<WpfWebClient.ServiceReferenceEHEC.Strain> strainlist = new List<ServiceReferenceEHEC.Strain>(client.GetStrains());

            //Display all strains with name in Combobox
            ComboBoxStrains.ItemsSource = strainlist;
            ComboBoxStrains.DisplayMemberPath = "Name";

            client.Close();
        }

        private void btnAddFoodPlace_Click(object sender, RoutedEventArgs e)
        {
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();

            Exam exam = new Exam();

            exam.Date = dateboxExamDate.SelectedDate.Value;
            exam.Doctor = (Doctor)ComboBoxDoctors.SelectedValue;
            exam.Patient = (Person)ComboBoxPatients.SelectedValue;
            exam.Description = txtDescription.Text;
            exam.Strain = (Strain)ComboBoxStrains.SelectedValue;

            client.WriteExam(exam);

            client.Close();
        }
    }
}
