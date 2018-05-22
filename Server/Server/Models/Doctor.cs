using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Doctor
    {
        private int _DoctorId;
        private Person _Person;
        private Status _Status;

        [DataMember]
        public int DoctorId { get => _DoctorId; set => _DoctorId = value; }
        [DataMember]
        public Person Person { get => _Person; set => _Person = value; }
        [DataMember]
        public virtual Status Status { get => _Status; set => _Status = value; }

        [Obsolete("Only needed for serialization and materialization", true)]
        public Doctor() { }
        public Doctor (Person person, Status status)
        {
            this.Person = person;
            this.Status = status;
        }
    }
}