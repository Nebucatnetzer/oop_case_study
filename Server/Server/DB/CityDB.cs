using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class CityDB
    {
        public ICollection<City> GetAllCities()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.Cities
                    .Include("Country")
                    .ToList();
            }
        }
        public bool CreateCity(City city)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var country = ctx.Countries.FirstOrDefault(c => c.CountryID == city.Country.CountryID);

                    ctx.Countries.Attach(country);

                    ctx.Cities.Add(city);

                    city.Country = country;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e);
                return false;
            }
        }

        public bool UpdateCity(City city)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Cities.Attach(city);
                    ctx.Entry(city).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e);
                return false;
            }

        }
        public bool DeleteCity(City city)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Cities.Attach(city);
                    ctx.Cities.Remove(city);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e);
                return false;
            }
        }
    }
}
