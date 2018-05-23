using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebClient.ServiceReferenceEhec;

namespace WebClient
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ServiceClient client = new ServiceClient();

            // Verwenden Sie die client-Variable, um Vorgänge für den Dienst aufzurufen.

            Person p = new Person();
            
 

            // Schließen Sie den Client immer.
            client.Close();
        }
    }

    
}