using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Salutation
    {
        private int _SalutationId;
        private string _Name;

        [DataMember]
        public int SalutationId { get => _SalutationId; set => _SalutationId = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Salutation() { }
        public Salutation (string name)
        {
            this.Name = name;
        }
    }
}