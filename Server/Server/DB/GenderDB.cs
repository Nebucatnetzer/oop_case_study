using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class GenderDB
    {
        public ICollection<Gender> GetAllGenders()
        {
            using (Context ctx = new Context())
            {
                return ctx.Genders.ToList();
            }
        }
        public bool CreateGender(Gender gender)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Genders.Add(gender);
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

        public bool UpdateGender(Gender gender)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Genders.Attach(gender);
                    ctx.Entry(gender).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteGender(Gender gender)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Genders.Attach(gender);
                    ctx.Genders.Remove(gender);
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
