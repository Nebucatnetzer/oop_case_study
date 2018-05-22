using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ServiceReferenceEhec;

namespace WebClient
{
    public partial class _Default : Page
    {
        ServiceClient client = new ServiceClient();

        // Verwenden Sie die client-Variable, um Vorgänge für den Dienst aufzurufen.

        WebClient.ServiceReferenceEhec.Person p = new Person();



        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmitPerson_Click(object sender, EventArgs e)
        {
            p.City.CityId = Convert.ToInt32(txtCity.Text);
            p.FirstName = Convert.ToString(txtFirstName.Text);
            p.LastName = Convert.ToString(txtLastName.Text);
            p.Salutation.SalutationId = Convert.ToInt32(txtSalutation.Text);
            p.Gender.GenderId = Convert.ToInt32(txtGender.Text);
            p.StreetName = Convert.ToString(txtStreetName.Text);

            client.WritePatient(p);

            // Schließen Sie den Client immer.
            client.Close();
        }

        

    }
}