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
                    var patient = ctx.Persons.FirstOrDefault(p => p.PersonID == patientAtFoodPlace.Patient.PersonID);
                    var foodplace = ctx.FoodPlaces.FirstOrDefault(f => f.FoodPlaceID == patientAtFoodPlace.FoodPlace.FoodPlaceID);
                    var pcity = ctx.Cities.FirstOrDefault(c => c.CityID == patient.City.CityID);
                    var fcity = ctx.Cities.FirstOrDefault(c => c.CityID == patientAtFoodPlace.FoodPlace.City.CityID);
                    var pcountry = ctx.Countries.FirstOrDefault(c => c.CountryID == pcity.Country.CountryID);
                    var fcountry = ctx.Countries.FirstOrDefault(c => c.CountryID == fcity.Country.CountryID);
                    var salutation = ctx.Salutations.FirstOrDefault(s => s.SalutationID == patient.Salutation.SalutationID);
                    var gender = ctx.Genders.FirstOrDefault(g => g.GenderID == patient.Gender.GenderID);

                    ctx.Cities.Attach(pcity);
                    ctx.Cities.Attach(fcity);
                    ctx.Countries.Attach(pcountry);
                    ctx.Countries.Attach(fcountry);
                    ctx.Genders.Attach(gender);
                    ctx.Salutations.Attach(salutation);
                    ctx.Persons.Attach(patient);
                    ctx.FoodPlaces.Attach(foodplace);

                    patientAtFoodPlace.FoodPlace = foodplace;
                    patientAtFoodPlace.Patient = patient;

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
