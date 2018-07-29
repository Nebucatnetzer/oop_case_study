using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class PatientDB
    {
        public ICollection<Patient> GetAllPatients()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.Patients
                    .Include("Gender")
                    .Include("City")
                    .Include("Salutation")
                    .ToList();
            }
        }
        public bool CreatePatient(Patient doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Patients.Add(doctor);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePatient(Patient doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Patients.Attach(doctor);
                    ctx.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeletePatient(Patient doctor)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Patients.Attach(doctor);
                    ctx.Patients.Remove(doctor);
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
