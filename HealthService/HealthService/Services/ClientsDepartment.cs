using HealthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Services
{
    class ClientsDepartment
    {
        private List <Patient> _clients;


        public ClientsDepartment()
        {
            _clients = new List<Patient>();
        }
        public List<Patient> GetPatients()
        {
            return _clients;
        }
        public Patient AddPatient(string name)
        {
            Patient newPatient = new Patient(name);
            return newPatient;
        }

        public bool DeletePatient(Guid id)
        {
            _clients.RemoveAll(client => client.GetId().Equals(id));
            return true;
        }
        public bool EditPatientDetails(Guid patientId, string newName)
        {
            _clients.Find(patient => patient.GetId().Equals(patientId)).UpdateDetails(newName);
            return true;
        }


    }
}
