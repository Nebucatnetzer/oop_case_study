using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.DB
{
    public class ResultDB
    {
        public List<Result> GetAllResults()
        {
            using (Context ctx = new Context())
            {
                return ctx.Results.ToList();
            }
        }
        public bool CreateResult(Result result)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Results.Add(result);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateResult(Result result)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Results.Attach(result);
                    ctx.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteResult(Result result)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Results.Attach(result);
                    ctx.Results.Remove(result);
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