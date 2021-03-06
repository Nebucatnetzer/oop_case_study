﻿using System.Collections.Generic;
using System.ServiceModel;
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
        void WriteCity(City city);
        [OperationContract]
        void WriteCountry(Country country);
        [OperationContract]
        void WriteFoodPlace(FoodPlace foodplace);
        [OperationContract]
        void WriteStrain(Strain strain);
        [OperationContract]
        void WriteRelation(PatientAtFoodPlace relation);
        [OperationContract]
        ICollection<Gender> GetGenders();
        [OperationContract]
        ICollection<Salutation> GetSalutations();
        [OperationContract]
        ICollection<Strain> GetStrains();
        [OperationContract]
        ICollection<Doctor> GetDoctors();
        [OperationContract]
        ICollection<City> GetCities();
        [OperationContract]
        ICollection<Country> GetCountries();
        [OperationContract]
        ICollection<FoodPlace> GetFoodPlaces();
        [OperationContract]
        ICollection<PatientAtFoodPlace> GetRelations();
        [OperationContract]
        ICollection<Person> GetPersons();
    }
}
