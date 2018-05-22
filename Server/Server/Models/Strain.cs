﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Models
{
    [DataContract]
    public class Strain
    {
        private int _StrainId;
        private string _Name;

        [DataMember]
        public int StrainId { get => _StrainId; set => _StrainId = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Strain() { }
        public Strain (string name)
        {
            this.Name = name;
        }
    }
}