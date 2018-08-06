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
                    var city = ctx.Cities.FirstOrDefault(c => c.CityID == doctor.City.CityID);
                    var country = ctx.Countries.FirstOrDefault(c => c.CountryID == doctor.City.Country.CountryID);
                    var salutation = ctx.Salutations.FirstOrDefault(s => s.SalutationID == doctor.Salutation.SalutationID);
                    var gender = ctx.Genders.FirstOrDefault(g => g.GenderID == doctor.Gender.GenderID);

                    ctx.Cities.Attach(city);
                    ctx.Countries.Attach(country);
                    ctx.Genders.Attach(gender);
                    ctx.Salutations.Attach(salutation);

                    doctor.City = city;
                    doctor.Salutation = salutation;
                    doctor.Gender = gender;

                    ctx.Doctors.Add(doctor);
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
                System.Diagnostics.Trace.WriteLine(e);
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
                System.Diagnostics.Trace.WriteLine(e);
                return false;
            }
        }
    }
}
