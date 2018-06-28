using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Server.Helper;
using Server.Models;
using Server.DB;

namespace Server
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new EntitiesContextInitializer());
            // Workaround to get the DB filled at first run
            SalutationDB salutations = new SalutationDB();
            ICollection<Salutation> salutationList = new List<Salutation>();
            salutationList = salutations.GetAllSalutations();
            // End of workaround
        }
    }
}