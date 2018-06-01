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
        private int _StatusID;
        private string _Name;

        [DataMember]
        public int StatusID { get => _StatusID; set => _StatusID = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Status() { }
        public Status (string name)
        {
            this.Name = name;
        }
    }
}