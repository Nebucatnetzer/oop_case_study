using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Status
    {
        private int _StatusId;
        private string _Name;

        [DataMember]
        public int StatusId { get => _StatusId; set => _StatusId = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Status() { }
        public Status (string name)
        {
            this.Name = name;
        }
    }
}