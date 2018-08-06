using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class StrainDB
    {
        public ICollection<Strain> GetAllStrains()
        {
            using (Context ctx = new Context())
            {
                return ctx.Strains.ToList();
            }
        }
        public bool CreateStrain(Strain strain)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Strains.Add(strain);
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

        public bool UpdateStrain(Strain strain)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Strains.Attach(strain);
                    ctx.Entry(strain).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteStrain(Strain strain)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Strains.Attach(strain);
                    ctx.Strains.Remove(strain);
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
