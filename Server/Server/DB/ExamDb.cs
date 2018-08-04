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
                    ctx.Exams.Add(exam);
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
                System.Diagnostics.Trace.WriteLine(e.Message);
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
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }
    }
}
