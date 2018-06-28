using System.Collections.Generic;
using System.Runtime.Serialization;

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
        private ICollection<PatientAtFoodPlace> _PatientAtFoodPlaces;

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
        public ICollection<PatientAtFoodPlace> PatientAtFoodPlaces
        {
            get => _PatientAtFoodPlaces;
            set => _PatientAtFoodPlaces= value;
        }

        public FoodPlace() { }
        public FoodPlace(City city, string streetname, string streetnumber,
                         string name,string description)
        {
            this.City = city;
            this.Streetname = streetname;
            this.Streetnumber = streetnumber;
            this.Name = name;
            this.Description = description;
        }
    }
}