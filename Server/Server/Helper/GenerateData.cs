using System;
using System.Collections.Generic;
using System.Linq;
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
        private static List<FoodPlace> foodPlaces = new List<FoodPlace>();
        private static List<PatientAtFoodPlace> relations = new List<PatientAtFoodPlace>();
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
        private static List<string> CityFirstPart = new List<string>(new string[]
        {
            "Burg", "Gross", "Klein", "Ober", "Unter", "Riedt", "Enten", "Lang", "Kurz", "Wies",
            "Alt", "Arn", "Bleich", "Bad", "Berg", "Rhein", "Mühl"
        });
        private static List<string> CitySecondPart = new List<string>(new string[]
        {
            "dorf", "thal", "ikon", "hausen", "langen", "bach", "baden", "felden", "stein", "stadt",
            "matten", "weier", "wald", "see", "heim", "kirchen", "weiden"
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
            int FirstPartLength = CityFirstPart.Count();
            int SecondPartLength = CitySecondPart.Count();
            int Counter = FirstPartLength * SecondPartLength;
            while (Cities.Count() != Counter)
            {
                int FirstPart = Rnd.Next(1, FirstPartLength);
                int SecondPart = Rnd.Next(1, SecondPartLength);
                string CityName = CityFirstPart[FirstPart] + CitySecondPart[SecondPart];
                int ZipCode = Rnd.Next(1000, 10000);
                int CountryID = Rnd.Next(1, CountryList.Count());
                Country country = Countries[CountryID];
                City NewCity = new City(CityName, ZipCode, country);
                if (Cities.Any(c => c.ZipCode == NewCity.ZipCode))
                {
                    continue;
                }
                else
                {
                    Cities.Add(NewCity);
                }
            }
            return Cities;
        }
        public static List<Doctor> CreateDoctors()
        {
            int FirstNamesAmount = FirstNames.Count();
            int LastNamesAmount = LastNames.Count();
            int CitiesAmount = Cities.Count();
            for (int i = 0; i < FirstNamesAmount; i++)
            {
                for (int j = 0; j < LastNamesAmount; j++)
                {
                    int RandomCityID = Rnd.Next(1, CitiesAmount);
                    City PersonCity = Cities[RandomCityID];
                    String Streetname = "Musterstrasse ";
                    String StreetNumber = Rnd.Next(1, 20).ToString();

                    Doctor doctor = new Doctor(
                        FirstNames[i],
                        LastNames[j],
                        Genders[0],
                        Salutations[0], Streetname, StreetNumber, PersonCity);
                    Doctors.Add(doctor);
                }
            }
            return Doctors;
        }
        public static List<FoodPlace> CreateFoodPlaces()
        {
            for (int i = 0; i < 50; i++)
            {
                foodPlaces.Add(new FoodPlace()
                {
                    Name = "FoodPlace" + i,
                    Description = "b" + i,
                    City = Cities[i],
                    Streetname = "Musterstrase",
                    Streetnumber = i.ToString()
                });
            }
            return foodPlaces;
        }
     }
}
