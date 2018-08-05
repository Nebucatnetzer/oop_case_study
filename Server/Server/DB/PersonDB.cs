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
                    var salutation = ctx.Salutations.FirstOrDefault(c => c.SalutationID == person.Salutation.SalutationID);
                    var gender = ctx.Genders.FirstOrDefault(c => c.GenderID == person.Gender.GenderID);
                    var country = ctx.Countries.FirstOrDefault(c => c.CountryID == city.Country.CountryID);

                    ctx.Cities.Attach(city);
                    ctx.Salutations.Attach(salutation);
                    ctx.Genders.Attach(gender);
                    ctx.Countries.Attach(country);

                    person.City = city;
                    person.Salutation = salutation;
                    person.Gender = gender;

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
