using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.DB
{
    public class StatusDB
    {
        public List<Status> GetAllStatus()
        {
            using (Context ctx = new Context())
            {
                return ctx.Status.ToList();
            }
        }
        public bool CreateStatus(Status status)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Status.Add(status);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStatus(Status status)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Status.Attach(status);
                    ctx.Entry(status).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteStatus(Status status)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Status.Attach(status);
                    ctx.Status.Remove(status);
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