using System.Data.Entity;
using Server.DB;

namespace Server.Helper
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var salutations = GenerateData.CreateSalutations();
            var genders = GenerateData.CreateGenders();
            var countries = GenerateData.CreateCountries();
            var cities = GenerateData.CreateCities();
            var doctors = GenerateData.CreateDoctors();

            foreach (var s in salutations)
            {
                context.Salutations.Add(s);
            }
            foreach (var g in genders)
            {
                context.Genders.Add(g);
            }
            foreach (var c in countries)
            {
                context.Countries.Add(c);
            }
            foreach (var c in cities)
            {
                context.Cities.Add(c);
            }
            foreach (var d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

        }
    }
}