using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.DB
{
    public class SalutationDB
    {
        public List<Salutation> GetAllSalutations()
        {
            using (Context ctx = new Context())
            {
                return ctx.Salutations.ToList();
            }
        }
        public bool CreateSalutation(Salutation salutation)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Salutations.Add(salutation);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSalutation(Salutation salutation)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Salutations.Attach(salutation);
                    ctx.Entry(salutation).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteSalutation(Salutation salutation)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Salutations.Attach(salutation);
                    ctx.Salutations.Remove(salutation);
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