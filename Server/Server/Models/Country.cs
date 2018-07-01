using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class Country
    {
        private int _CountryID;
        private string _Name;

        [DataMember]
        public int CountryID { get => _CountryID; set => _CountryID = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Country() { }
        public Country (string name)
        {
            this.Name = name;
        }
    }
}