using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.DB
{
    public class CityDB
    {
        public List<City> GetAllCitys()
        {
            using (Context ctx = new Context())
            {
                return ctx.Cities.ToList();
            }
        }
        public bool CreateCity(City city)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Cities.Add(city);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}