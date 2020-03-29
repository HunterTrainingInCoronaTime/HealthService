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

        }
        public List<Patient> GetPatients()
        {
            return _clients;
        }
        public bool AddPatient(string name)
        {
            Patient newPatient = new Patient(name);
            return true;
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
