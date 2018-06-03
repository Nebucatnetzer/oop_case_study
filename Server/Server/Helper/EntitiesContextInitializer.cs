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
            List<string> salutationList = new List<string>(new string[]
            {
                "Dr.", "Frau", "Herr"
            });
            List<string> genderList = new List<string>(new string[]
            {
                "Männlich", "Weiblich"
            });

            foreach (var s in salutationList)
            {
                Salutation newSalutation = new Salutation(s);
                context.Salutations.Add(newSalutation);
            }
            foreach (var g in genderList)
            {
                Gender newGender = new Gender(g);
                context.Genders.Add(newGender);
            }
            context.SaveChanges();
            Gender gender = context.Genders.FirstOrDefault();
            Salutation salutation = context.Salutations.FirstOrDefault();
            Country country = new Country("Schweiz");
            City city = new City("Herzogenbuchsee", 3360, country);
            Status status = new Status("Regionalarzt");
            Doctor doctor = new Doctor("Max", "Ötker", gender,
                salutation, "Musterstrasse 12", city, status);
            context.Doctors.Add(doctor);
            context.SaveChanges();
        }
    }
}