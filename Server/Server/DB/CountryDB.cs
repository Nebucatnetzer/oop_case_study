using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class CountryDB
    {
        public ICollection<Country> GetAllCountries()
        {
            using (Context ctx = new Context())
            {
                return ctx.Countries.ToList();
            }
        }
        public bool CreateCountry(Country country)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Countries.Add(country);
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

        public bool UpdateCountry(Country country)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Countries.Attach(country);
                    ctx.Entry(country).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteCountry(Country country)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Countries.Attach(country);
                    ctx.Countries.Remove(country);
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
