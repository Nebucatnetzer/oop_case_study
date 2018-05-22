using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class City
    {
        private int _CityId;
        private string _Name;
        private int _ZipCode;
        private Country _Counry;

        [DataMember]
        public int CityId { get => _CityId; set => _CityId= value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }
        [DataMember]
        public int ZipCode { get => _ZipCode; set => _ZipCode = value; }
        [DataMember]
        public virtual Country Country { get => _Counry; set => _Counry = value; }

        [Obsolete("Only needed for serialization and materialization", true)]
        public City() { }

        public City (string name, int zipCode, Country country)
        {
            this.Name = name;
            this.ZipCode = zipCode;
            this.Country = country;
        }
    }
}