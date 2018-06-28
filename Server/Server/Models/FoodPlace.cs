using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [DataContract]
    public class FoodPlace
    {
        private int _FoodPlaceID;
        private City _City;
        private string _Streetname;
        private string _Streetnumber;
        private string _Name;
        private string _Description;
        private Person _Patient;
        private DateTime _Date;

        [DataMember]
        public int FoodPlaceID { get => _FoodPlaceID; set => _FoodPlaceID = value; }       
        [DataMember]
        public City City { get => _City; set => _City = value; }
        [DataMember]
        public string Streetname { get => _Streetname; set => _Streetname = value; }
        [DataMember]
        public string Streetnumber { get => _Streetnumber; set => _Streetnumber = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }
        [DataMember]
        public string Description { get => _Description; set => _Description = value; }
        [DataMember]
        public Person Patient { get => _Patient; set => _Patient = value; }
        [DataMember]
        public DateTime Date { get => _Date; set => _Date = value; }

        public FoodPlace() { }
        public FoodPlace(City city, string streetname, string streetnumber,
                         string name,string description, Person patient,
                         DateTime date)
        {
            this.City = city;
            this.Streetname = streetname;
            this.Streetnumber = streetnumber;
            this.Name = name;
            this.Description = description;
            this.Patient = patient;
            this.Date = date;
        }
    }
}