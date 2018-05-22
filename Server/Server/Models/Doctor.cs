using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Doctor : Person
    {
        private int _DoctorId;
        private Status _Status;

        [DataMember]
        public int DoctorId { get => _DoctorId; set => _DoctorId = value; }
        [DataMember]
        public virtual Status Status { get => _Status; set => _Status = value; }

        public Doctor() { }
        public Doctor(string firstName, string lastName, Gender gender, Salutation salutation,
                       string streetName, City city, Status status)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Salutation = salutation;
            this.StreetName = streetName;
            this.City = city;
            this.Status = status;
        }
    }
}