using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class Doctor : Person
    {
        private int _DoctorID;

        [DataMember]
        public int DoctorID { get => _DoctorID; set => _DoctorID = value; }

        public Doctor() { }
        public Doctor(string firstName, string lastName, Gender gender, Salutation salutation,
                       string streetName, string streetNumber, City city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Salutation = salutation;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.City = city;
        }
    }
}
