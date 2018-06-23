using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Exam
    {
        private int _ExamID;
        private DateTime _Date;
        private Doctor _Doctor;
        private Person _Patient;
        private Result _Result;

        [DataMember]
        public int ExamID  { get => _ExamID; set => _ExamID = value; }
        [DataMember]
        public DateTime Date { get => _Date; set => _Date = value; }
        [DataMember]
        public Doctor Doctor { get => _Doctor; set => _Doctor = value; }
        [DataMember]
        public Person Patient { get => _Patient; set => _Patient = value; }
        [DataMember]
        public Result Result { get => _Result; set => _Result = value; }

        public Exam() { }
        public Exam (Doctor doctor, Person patient, Result result)
        {
            this.Date = DateTime.Now;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Result = result;
        }
    }
}