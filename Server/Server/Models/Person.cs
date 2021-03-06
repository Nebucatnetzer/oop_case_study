﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    [KnownType(typeof(Doctor))]
    public class Person
    {
        private int _PersonID;
        private string _FirstName;
        private string _LastName;
        private Gender _Gender;
        private Salutation _Salutation;
        private string _StreetName;
        private string _StreetNumber;
        private City _City;
        private ICollection<PatientAtFoodPlace> _PatientAtFoodPlaces;

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
        public string StreetNumber { get => _StreetNumber; set => _StreetNumber = value; }
        [DataMember]
        public virtual City City { get => _City; set => _City = value; }
        [DataMember]
        public ICollection<PatientAtFoodPlace> PatientAtFoodPlaces
        {
            get => _PatientAtFoodPlaces;
            set => _PatientAtFoodPlaces= value;
        }

        public Person() { }
        public Person (string firstName, string lastName, Gender gender, Salutation salutation,
                       string streetName, string streetNumber, City city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Salutation = salutation;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.City = city;
        }
    }
}