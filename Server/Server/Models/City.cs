using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class City
    {
        private int _CityID;
        private string _Name;
        private int _ZipCode;
        private Country _Counry;

        [DataMember]
        public int CityID { get => _CityID; set => _CityID = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }
        [DataMember]
        public int ZipCode { get => _ZipCode; set => _ZipCode = value; }
        [DataMember]
        public virtual Country Country { get => _Counry; set => _Counry = value; }

        public City() { }
        public City (string name, int zipCode, Country country)
        {
            this.Name = name;
            this.ZipCode = zipCode;
            this.Country = country;
        }
    }
}