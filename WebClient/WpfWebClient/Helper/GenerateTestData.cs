using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWebClient.ServiceReferenceEHEC;

namespace WpfWebClient.Helper
{
    public static class GenerateTestData
    {
        private static List<FoodPlace> Foodplaces = new List<FoodPlace>();
        private static List<Exam> Exams = new List<Exam>();
        private static Random random = new Random();

        private static List<String> FoodPlaceNameFirstPart = new List<string>(new string[]
        {
            "The ", "Tony's ", "Best ", "Paulas ", "Golden ", "Platinum ", "Super "
        });

        private static List<String> FoodPlaceNameSecondPart = new List<string>(new string[]
        {
            "Pizzaplace", "Meatclub", "Veganitorium", "Applepie", "Burger", "Esspalast", "Döner", "Bananorama"
        });

        private static List<String> FoodPlaceDescription = new List<string>(new string[]
        {
            "Einfach unglaublich", "Die grössten der ganzen Stadt", "Ziemlich durchschnittlich", "Einmal alles ohne scharf bitte",
            "Das ist eine B-Schreibung", "Etwas teuer aber trotzdem einen Besuch Wert", "Grösster Müll EVER", "Do ane chumi NIE MEH!"
        });

        private static List<String> FoodPlaceStreetName = new List<string>(new string[]
{
            "Hansestrasse", "Dorfweg", "Rumpelstrasse", "Hauptstrasse",
            "Blumengasse", "Pimpelpfad", "Im Grund", "Schotterweg"
});

        public static List<FoodPlace> CreateFoodPlaces()
        {

            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();
            List<WpfWebClient.ServiceReferenceEHEC.City> cities = new List<ServiceReferenceEHEC.City>(client.GetCities());

            int FirstPartLength = FoodPlaceNameFirstPart.Count();
            int SecondPartLength = FoodPlaceNameSecondPart.Count();
            int Counter = FirstPartLength * SecondPartLength;

            int i = 1;
            while (i < 20)
            {
                int FirstPart = random.Next(1, FirstPartLength);
                int SecondPart = random.Next(1, SecondPartLength);
                int Description = random.Next(FoodPlaceDescription.Count);
                string FoodPlaceDescr = FoodPlaceDescription[Description];
                int StreetName = random.Next(FoodPlaceStreetName.Count);
                string FoodPlacesm = FoodPlaceStreetName[StreetName];

                string FoodPlaceName = FoodPlaceNameFirstPart[FirstPart] + FoodPlaceNameSecondPart[SecondPart];
                string streetname = FoodPlacesm;
                string fpdescr = FoodPlaceDescr;
                int StreetNumber = random.Next(1, 100);
                int CityID = random.Next(1, cities.Count());
                City city = cities[CityID];
                FoodPlace NewFoodPlace = new FoodPlace();

                NewFoodPlace.Name = FoodPlaceName;
                NewFoodPlace.Streetname = streetname;
                NewFoodPlace.Streetnumber = StreetNumber.ToString();
                NewFoodPlace.Description = fpdescr;
                NewFoodPlace.City = city;



                Foodplaces.Add(NewFoodPlace);
                i++;
            }

            return Foodplaces;
        }

        public static List<PatientAtFoodPlace> CreatePatientAtFoodPlaces()
        {
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();
            List<WpfWebClient.ServiceReferenceEHEC.FoodPlace> foodPlaces = new List<ServiceReferenceEHEC.FoodPlace>(client.GetFoodPlaces());
            List<WpfWebClient.ServiceReferenceEHEC.Person> patients = new List<ServiceReferenceEHEC.Person>(client.GetPersons());

            foodPlaces.OrderBy(x => random.Next()).Take(50);
            

        }

        return x
    }
}
