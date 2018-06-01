using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Person
    {
        private int _PersonID;
        private string _FirstName;
        private string _LastName;
        private Gender _Gender;
        private Salutation _Salutation;
        private string _StreetName;
        private City _City;

        [DataMember]
        public int PersonID { get => _PersonID; set => _PersonID = value; }
        [DataMember]
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        [DataMember]
        public string LastName { get => _LastName; set => _LastName = value; }
        [DataMember]
        public virtual Gender Gender { get => _Gender; set => _Gender = value; }
        [DataMember]
        public virtual Salutation Salutation { get => _Salutation; set => _Salutation = value; }
        [DataMember]
        public string StreetName { get => _StreetName; set => _StreetName = value; }
        [DataMember]
        public virtual City City { get => _City; set => _City = value; }

        public Person() { }
        public Person (string firstName, string lastName, Gender gender, Salutation salutation,
                       string streetName, City city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Salutation = salutation;
            this.StreetName = streetName;
            this.City = city;
        }
    }
}