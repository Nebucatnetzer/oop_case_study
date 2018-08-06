using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.DB
{
    public class ExamDB
    {
        public ICollection<Exam> GetAllExams()
        {
            using (Context ctx = new Context())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                return ctx.Exams
                    .Include("Patient")
                    .Include("Doctor")
                    .Include("Strain")
                    .ToList();
            }
        }
        public bool CreateExam(Exam exam)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    var patient = ctx.Persons.FirstOrDefault(p => p.PersonID == exam.Patient.PersonID);
                    var pCity = ctx.Cities.FirstOrDefault(c => c.CityID == patient.City.CityID);
                    var pCountry = ctx.Countries.FirstOrDefault(c => c.CountryID == pCity.Country.CountryID);
                    var pGender = ctx.Genders.FirstOrDefault(g => g.GenderID == patient.Gender.GenderID);
                    var pSalutation = ctx.Salutations.FirstOrDefault(s => s.SalutationID == patient.Salutation.SalutationID);
                    var doctor = ctx.Doctors.FirstOrDefault(d => d.PersonID == exam.Doctor.PersonID);
                    var dCity = ctx.Cities.FirstOrDefault(c => c.CityID == doctor.City.CityID);
                    var dCountry = ctx.Countries.FirstOrDefault(c => c.CountryID == dCity.Country.CountryID);
                    var dGender = ctx.Genders.FirstOrDefault(g => g.GenderID == doctor.Gender.GenderID);
                    var dSalutation = ctx.Salutations.FirstOrDefault(s => s.SalutationID == doctor.Salutation.SalutationID);
                    var strain = ctx.Strains.FirstOrDefault(s => s.StrainID == exam.Strain.StrainID);

                    ctx.Persons.Attach(patient);
                    ctx.Doctors.Attach(doctor);
                    ctx.Cities.Attach(pCity);
                    ctx.Cities.Attach(dCity);
                    ctx.Countries.Attach(dCountry);
                    ctx.Countries.Attach(pCountry);
                    ctx.Genders.Attach(dGender);
                    ctx.Genders.Attach(pGender);
                    ctx.Salutations.Attach(dSalutation);
                    ctx.Salutations.Attach(pSalutation);

                    exam.Doctor = doctor;
                    exam.Patient = patient;
                    exam.Strain = strain;

                    ctx.Exams.Add(exam);
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

        public bool UpdateExam(Exam exam)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Exams.Attach(exam);
                    ctx.Entry(exam).State = System.Data.Entity.EntityState.Modified;
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
        public bool DeleteExam(Exam exam)
        {
            try
            {
                using (Context ctx = new Context())
                {
                    ctx.Exams.Attach(exam);
                    ctx.Exams.Remove(exam);
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
