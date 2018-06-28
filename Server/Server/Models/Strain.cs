using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class Strain
    {
        private int _StrainID;
        private string _Name;

        [DataMember]
        public int StrainID { get => _StrainID; set => _StrainID = value; }
        [DataMember]
        public string Name { get => _Name; set => _Name = value; }

        public Strain() { }
        public Strain (string name)
        {
            this.Name = name;
        }
    }
}