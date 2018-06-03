using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.Helper
{
    public static class GenerateData
    {
        private static List<Salutation> salutations = new List<Salutation>();
        private static List<Gender> genders = new List<Gender>();
        private static List<Doctor> doctors = new List<Doctor>();

        private static List<string> salutationList = new List<string>(new string[]
        {
            "Dr.", "Frau", "Herr"
        });
        private static List<string> genderList = new List<string>(new string[]
        {
            "Männlich", "Weiblich"
        });
        public static List<Salutation> CreateSalutations()
        {
            foreach (var s in salutationList)
            {
                salutations.Add(new Salutation(s)); 
            }
            return salutations;
        }
        public static List<Gender> CreateGenders()
        {
            foreach (var s in salutationList)
            {
                genders.Add(new Gender(s)); 
            }
            return genders;
        }
        public static List<Doctor> CreateDoctors()
        {
            Country country = new Country("Schweiz");
            City city = new City("Herzogenbuchsee", 3360, country);
            Status status = new Status("Regionalarzt");
            Doctor doctor = new Doctor("Max", "Ötker", genders[0],
                salutations[0], "Musterstrasse 12", city, status);
            doctors.Add(doctor);
            return doctors;
        }
    }
}