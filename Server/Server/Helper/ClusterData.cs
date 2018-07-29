using System.Collections.Generic;
using Server.DB;

namespace Server.Models
{
    public class ClusterData
    {
        private List<Person> Patients { get; set; }
        private List<FoodPlace> FoodPlaces { get; set; }
        private List<PatientAtFoodPlace> Relations { get; set; }
        public ClusterData()
        {
            Context ctx = new Context();
            this.Patients = new List<Person>();
            this.FoodPlaces = new List<FoodPlace>();
            PatientAtFoodPlaceDB relationsDB = new PatientAtFoodPlaceDB();
            this.Relations = new List<PatientAtFoodPlace>(relationsDB.GetAllRelations());
            foreach (var relation in this.Relations)
            {
                this.Patients.Add(relation.Patient);
                this.FoodPlaces.Add(relation.FoodPlace);
            }
        }
        public List<Node> GenerateNodes()
        {
            List<Node> Nodes = new List<Node>();
            foreach (var patient in this.Patients)
            {
                Node node = new Node
                {
                    id = patient.PersonID,
                    label = patient.FirstName + " " + patient.LastName,
                };
                Nodes.Add(node);
            }
            int counter = 0;
            foreach (var foodplace in this.FoodPlaces)
            {
                Node node = new Node
                {
                    id = foodplace.FoodPlaceID,
                    label = foodplace.Name + ", " + foodplace.City.Name + ", " + foodplace.City.Country.Name,
                };
                Nodes.Add(node);
                counter++;
            }
            return Nodes;
        }
        public List<Edge> GenerateEdges()
        {
            List<Edge> Edges = new List<Edge>();
            foreach (var relation in this.Relations)
            {
                Edge edge = new Edge
                {
                    from = relation.FoodPlaceID,
                    to = relation.PatientID
                };
                Edges.Add(edge);
            }
            return Edges;
        }
    }
}
