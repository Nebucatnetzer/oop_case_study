using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class PatientAtFoodPlaceDB
    {
        public ICollection<PatientAtFoodPlace> GetAllRelations()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.PatientAtFoodPlaces
                    .Include("Patient")
                    .Include("FoodPlace")
                    .Include("FoodPlace.City")
                    .Include("FoodPlace.City.Country")
                    .ToList();
            }
        }
        public bool CreateRelation(PatientAtFoodPlace patientAtFoodPlace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.PatientAtFoodPlaces.Add(patientAtFoodPlace);
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

        public bool UpdateRelation(PatientAtFoodPlace patientAtFoodPlace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.PatientAtFoodPlaces.Attach(patientAtFoodPlace);
                    ctx.Entry(patientAtFoodPlace).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteRelation(PatientAtFoodPlace patientAtFoodPlace)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.PatientAtFoodPlaces.Attach(patientAtFoodPlace);
                    ctx.PatientAtFoodPlaces.Remove(patientAtFoodPlace);
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
