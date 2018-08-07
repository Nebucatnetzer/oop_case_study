using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [DataContract]
    public class PatientAtFoodPlace
    {
        [DataMember]
        public int PatientAtFoodPlaceID { get; set; }
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int FoodPlaceID { get; set; }
        [DataMember]
        [Column(TypeName = "Date")]
        public DateTime VistingDate { get; set; }

        [DataMember]
        public virtual Person Patient { get; set; }
        [DataMember]
        public virtual FoodPlace FoodPlace { get; set; }
    }
}