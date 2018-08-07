using System;
using Server.Models;
using Newtonsoft.Json;

namespace Server
{
    public partial class home : System.Web.UI.Page
    {
        protected string nodes { get; set; }
        protected string edges { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ClusterData cd = new ClusterData();
            this.nodes = JsonConvert.SerializeObject(cd.GenerateNodes());
            this.edges = JsonConvert.SerializeObject(cd.GenerateEdges());
        }
    }
}