using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class DoctorDB
    {
        public ICollection<Doctor> GetAllDoctors()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.Doctors
                    .Include("Gender")
                    .Include("City")
                    .Include("Salutation")
                    .ToList();
            }
        }
        public bool CreateDoctor(Doctor doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Doctors.Add(doctor);
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

        public bool UpdateDoctor(Doctor doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Doctors.Attach(doctor);
                    ctx.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteDoctor(Doctor doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Doctors.Attach(doctor);
                    ctx.Doctors.Remove(doctor);
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
