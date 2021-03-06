﻿using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class Salutation
    {
        private int _SalutationID;
        private string _Name;

        [DataMember]
        public int SalutationID { get => _SalutationID; set => _SalutationID = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }
        public Salutation() { }
        public Salutation (string name)
        {
            this.Name = name;
        }
    }
}