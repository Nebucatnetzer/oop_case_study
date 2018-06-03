using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Models;

namespace Server.Helper
{
    public static class GenerateData
    {
        private static List<Salutation> Salutations = new List<Salutation>();
        private static List<Gender> Genders = new List<Gender>();
        private static List<Doctor> Doctors = new List<Doctor>();
        private static List<Country> Countries = new List<Country>();
        private static List<City> Cities = new List<City>();
        private static List<Status> Statuses = new List<Status>();
        private static Random Rnd = new Random();

        private static List<string> SalutationList = new List<string>(new string[]
        {
            "Dr.", "Frau", "Herr"
        });
        private static List<string> GenderList = new List<string>(new string[]
        {
            "Männlich", "Weiblich"
        });
        private static List<string> CountryList = new List<string>(new string[]
        {
            "Schweiz", "Deutschland", "Österreich"
        });
        private static List<string> CityList = new List<string>(new string[]
        {
            "Herzogenbuchsee", "Langenthal", "Olten", "Bern", "Lyssach",
            "Zürich", "Genf", "Hamburg", "Berlin", "München", "Main", "Wien",
            "Entenhausen", "Altena", "Erlangen", "Güsten", "Heubach", "Langendorf",
            "Münster", "Wiesbaden"
        });
        private static List<string> FirstNames = new List<string>(new string[]
        {
            "Max", "Tom", "Michael", "Andreas", "David", "Stefan", "Ivan",
            "Adrien", "Simon", "Sven", "Nino", "Steven", "Martin", "Christian"
        });
        private static List<string> LastNames = new List<string>(new string[]
        {
            "Müller", "Meier", "Muster", "Bucher", "Schmidt", "Fink", "Steuri",
            "Meister", "Schär", "Eberhard", "Zingg", "Howald", "Aebi", "Feldmann"
        });
        private static List<string> StatusList = new List<string>(new string[]
        {
            "Regionalarzt", "Kantonsarzt"
        });
        public static List<Salutation> CreateSalutations()
        {
            foreach (var s in SalutationList)
            {
                Salutations.Add(new Salutation(s)); 
            }
            return Salutations;
        }
        public static List<Gender> CreateGenders()
        {
            foreach (var g in GenderList)
            {
                Genders.Add(new Gender(g)); 
            }
            return Genders;
        }
        public static List<Country> CreateCountries()
        {
            foreach (var c in CountryList)
            {
                Countries.Add(new Country(c)); 
            }
            return Countries;
        }
        public static List<City> CreateCities()
        {
            foreach (var c in CityList)
            {
                int ZipCode = Rnd.Next(1000, 10000);
                int CountryID = Rnd.Next(1, CountryList.Count());
                Country country = Countries[CountryID];
                City NewCity = new City(c, ZipCode, country); 
                Cities.Add(NewCity);
            }
            return Cities;
        }
        public static List<Status> CreateStatuses()
        {
            foreach (var s in StatusList)
            {
                Statuses.Add(new Status(s));
            }
            return Statuses;
        }
        public static List<Doctor> CreateDoctors()
        {
            int Counter = Cities.Count();
            for (int i = 0; i < Counter; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    City PersonCity = Cities[i];
                    Status DoctorStatus = Statuses[0];
                    String Streetname = "Musterstrasse " + Rnd.Next(1, 20).ToString();

                    Doctor doctor = new Doctor(
                        FirstNames[Rnd.Next(1, FirstNames.Count())],
                        LastNames[Rnd.Next(1, LastNames.Count())],
                        Genders[0],
                        Salutations[0], Streetname, PersonCity, DoctorStatus);
                    Doctors.Add(doctor);
                }
            }
            return Doctors;
        }
    }
}