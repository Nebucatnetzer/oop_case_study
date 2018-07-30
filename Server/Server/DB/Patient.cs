using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("Patients")]
    [DataContract]
    public class Patient : Person
    {
        public Patient() { }
        public Patient(string firstName, string lastName, Gender gender, Salutation salutation,
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
