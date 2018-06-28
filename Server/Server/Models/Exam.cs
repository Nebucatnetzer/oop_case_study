﻿using System;
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
        private Strain _Strain;
        private string _Description;

        [DataMember]
        public int ExamID  { get => _ExamID; set => _ExamID = value; }
        [DataMember]
        public DateTime Date { get => _Date; set => _Date = value; }
        [DataMember]
        public Doctor Doctor { get => _Doctor; set => _Doctor = value; }
        [DataMember]
        public Person Patient { get => _Patient; set => _Patient = value; }
        [DataMember]
        public string Description { get => _Description; set => _Description = value; }
        [DataMember]
        public Strain Strain { get => _Strain; set => _Strain = value; }

        public Exam() { }
        public Exam (Doctor doctor, Person patient, Strain strain, string description)
        {
            this.Date = DateTime.Now;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Strain = strain;
            this.Description = description;
        }
    }
}