using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Gender
    {
        private int _GenderId;
        private string _Name;

        [DataMember]
        public int GenderId { get => _GenderId; set => _GenderId = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Gender() { }
        public Gender (string name)
        {
            this.Name = name;
        }
    }
}