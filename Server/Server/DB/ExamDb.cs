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
                return ctx.Exams.ToList();
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}