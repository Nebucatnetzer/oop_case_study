using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Models;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public List<Doctor> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetGenders()
        {
            throw new NotImplementedException();
        }

        public List<Salutation> GetSalutations()
        {
            throw new NotImplementedException();
        }

        public List<Strain> GetStrains()
        {
            throw new NotImplementedException();
        }

        public void WriteCity(City city)
        {
            throw new NotImplementedException();
        }

        public void WriteCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void WriteExam(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void WritePatient(Person person)
        {
            throw new NotImplementedException();
        }

        public void WriteResult(Result result)
        {
            throw new NotImplementedException();
        }
    }
}
