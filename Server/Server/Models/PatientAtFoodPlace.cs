using System;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class PatientAtFoodPlace
    {
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int FoodPlaceID { get; set; }
        [DataMember]
        public DateTime VistingDate { get; set; }

        [DataMember]
        public virtual Person Patient { get; set; }
        [DataMember]
        public virtual FoodPlace FoodPlace { get; set; }
    }
}