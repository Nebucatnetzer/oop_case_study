using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Server.DB;
using Server.Models;

namespace Server.Helper
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {

            var salutations = GenerateData.CreateSalutations();
            var genders = GenerateData.CreateGenders();
            var doctors = GenerateData.CreateDoctors();

            foreach (var s in salutations)
            {
                context.Salutations.Add(s);
            }
            foreach (var g in genders)
            {
                context.Genders.Add(g);
            }
            foreach (var d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

        }
    }
}