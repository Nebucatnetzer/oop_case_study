using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Country
    {
        private int _CountryId;
        private string _Name;

        [DataMember]
        public int CountryId { get => _CountryId; set => _CountryId = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        [Obsolete("Only needed for serialization and materialization", true)]
        public Country() { }
        public Country (string name)
        {
            this.Name = name;
        }
    }
}