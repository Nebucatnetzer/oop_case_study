using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class PersonDB
    {
        public ICollection<Person> GetAllPersons()
        {
            using (Context ctx = new Context())
            {

                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.Persons
                    .Include("Gender")
                    .Include("City")
                    .Include("Salutation")
                    .ToList();
            }
        }
        public bool CreatePerson(Person person)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var city = ctx.Cities.FirstOrDefault(c => c.CityID == person.City.CityID);
                    var country = ctx.Countries.FirstOrDefault(c => c.CountryID == person.City.Country.CountryID);
                    var salutation = ctx.Salutations.FirstOrDefault(s => s.SalutationID == person.Salutation.SalutationID);
                    var gender = ctx.Genders.FirstOrDefault(g => g.GenderID == person.Gender.GenderID);

                    ctx.Cities.Attach(city);
                    ctx.Countries.Attach(country);
                    ctx.Genders.Attach(gender);
                    ctx.Salutations.Attach(salutation);
                    ctx.Persons.Add(person);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }

        public bool UpdatePerson(Person person)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Persons.Attach(person);
                    ctx.Entry(person).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }

        }
        public bool DeletePerson(Person person)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Persons.Attach(person);
                    ctx.Persons.Remove(person);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }
    }
}
