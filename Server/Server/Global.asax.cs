using System;
using System.Collections.Generic;
using System.Data.Entity;
using Server.Helper;
using Server.Models;
using Server.DB;
using System.Linq;

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
            Context ctx = new Context();
            var test = ctx.PatientAtFoodPlaces.FirstOrDefault(c => c.PatientAtFoodPlaceID == 1);
            if (test == null)
            {
                CreateRelations();
            }
        }
        public void CreateRelations()
        {
            List<PatientAtFoodPlace> relations = new List<PatientAtFoodPlace>();
            PersonDB dataccess = new PersonDB();
            FoodPlaceDB fooddb = new FoodPlaceDB();
            PatientAtFoodPlaceDB db = new PatientAtFoodPlaceDB();
            Random Rnd = new Random();
            ICollection<Person> patients = dataccess.GetAllPersons();
            List<FoodPlace> foodplaces = new List<FoodPlace>(fooddb.GetAllFoodPlaces());
            foreach (var patient in patients)
            {
                FoodPlace foodplace = foodplaces[Rnd.Next(0, 50)];
                relations.Add(new PatientAtFoodPlace()
                {
                    FoodPlaceID = foodplace.FoodPlaceID,
                    PatientID = patient.PersonID,
                    FoodPlace = foodplace,
                    VistingDate = DateTime.Now,
                    Patient = patient
                });
            }
            foreach (var item in relations)
            {
                db.CreateRelation(item);
            }
        }
    }
}
