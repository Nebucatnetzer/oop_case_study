using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void WritePatient(Person person);
        [OperationContract]
        void WriteExam(Exam exam);
        [OperationContract]
        void WriteResult(Result result);
        [OperationContract]
        void WriteCity(City city);
        [OperationContract]
        void WriteCountry(Country country);
        [OperationContract]
        void WriteFoodPlace(FoodPlace foodplace);
        [OperationContract]
        List<Gender> GetGenders();
        [OperationContract]
        List<Salutation> GetSalutations();
        [OperationContract]
        List<Strain> GetStrains();
        [OperationContract]
        List<Doctor> GetDoctors();
        [OperationContract]
        List<City> GetCities();
        [OperationContract]
        List<Country> GetCountries();
        [OperationContract]
        List<FoodPlace> GetFoodPlaces();
    }
}
