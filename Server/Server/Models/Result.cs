using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Result
    {
        private string _Name;
        private string _Description;
        private Strain _Strain;
        private bool _Infected;

        [DataMember]
        public string Name { get => _Name; set => _Name = value; }
        [DataMember]
        public string Description { get => _Description; set => _Description = value; }
        [DataMember]
        public Strain Strain { get => _Strain; set => _Strain = value; }
        [DataMember]
        public bool Infected { get => _Infected; set => _Infected = value; }

        public Result (string name, string description, Strain strain, bool infected)
        {
            this.Name = name;
            this.Description = description;
            this.Strain = strain;
            this.Infected = infected;
        }
    }
}