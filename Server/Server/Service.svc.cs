using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;
using Server.DB;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public List<Doctor> GetDoctors()
        {
            DoctorDB dataaccess = new DoctorDB();
            return dataaccess.GetAllDoctors();
        }

        public List<Gender> GetGenders()
        {
            GenderDB dataaccess = new GenderDB();
            return dataaccess.GetAllGenders();
        }

        public List<Salutation> GetSalutations()
        {
            SalutationDB dataaccess = new SalutationDB();
            return dataaccess.GetAllSalutations();
        }

        public List<Strain> GetStrains()
        {
            StrainDB dataaccess = new StrainDB();
            return dataaccess.GetAllStrains();
        }

        public List<City> GetCities()
        {
            CityDB dataaccess = new CityDB();
            return dataaccess.GetAllCities();
        }

        public List<Country> GetCountries()
        {
            CountryDB dataaccess = new CountryDB();
            return dataaccess.GetAllCountries();
        }

        public List<FoodPlace> GetFoodPlaces()
        {
            FoodPlaceDB dataaccess = new FoodPlaceDB();
            return dataaccess.GetAllFoodPlaces();
        }

        public void WriteCity(City city)
        {
            CityDB dataaccess = new CityDB();
            dataaccess.CreateCity(city);
        }

        public void WriteCountry(Country country)
        {
            CountryDB dataaccess = new CountryDB();
            dataaccess.CreateCountry(country);
        }

        public void WriteExam(Exam exam)
        {
            ExamDB dataaccess = new ExamDB();
            dataaccess.CreateExam(exam);
        }

        public void WritePatient(Person person)
        {
            PersonDB dataaccess = new PersonDB();
            dataaccess.CreatePerson(person);
        }

        public void WriteResult(Result result)
        {
            ResultDB dataaccess = new ResultDB();
            dataaccess.CreateResult(result);
        }

        public void WriteFoodPlace(FoodPlace foodplace)
        {
            FoodPlaceDB dataaccess = new FoodPlaceDB();
            dataaccess.CreateFoodPlace(foodplace);
        }
    }
}
