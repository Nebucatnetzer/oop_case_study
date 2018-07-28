using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.DB;

namespace Server.Models
{
    public class ClusterData
    {
        private List<Person> Doctors { get; set; }
        private List<City> Cities { get; set; }
        public ClusterData()
        {
            DoctorDB doctorDB = new DoctorDB();
            CityDB cityDB = new CityDB();
            this.Doctors = new List<Person>(doctorDB.GetAllDoctors());
            this.Cities = new List<City>(cityDB.GetAllCities());
        }
        public List<Node> GenerateNodes()
        {
            List<Node> Nodes = new List<Node>();
            foreach (var doctor in this.Doctors)
            {
                Node node = new Node
                {
                    id = doctor.PersonID,
                    label = doctor.FirstName + " " + doctor.LastName,
                    cid = doctor.City.ZipCode
                };
                Nodes.Add(node);
            }
            int counter = 0;
            foreach (var city in this.Cities)
            {
                Node node = new Node
                {
                    id = city.ZipCode,
                    label = city.Name,
                    cid = city.ZipCode
                };
                Nodes.Add(node);
                counter++;
            }
            return Nodes;
        }
        public List<Edge> GenerateEdges()
        {
            List<Edge> Edges = new List<Edge>();
            foreach (var doctor in this.Doctors)
            {
                Edge edge = new Edge
                {
                    from = doctor.City.ZipCode,
                    to = doctor.PersonID
                };
                Edges.Add(edge);
            }
            return Edges;
        }
    }
}