using HealthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Services
{
    class ResourcesDepartment
    {
        private List<Doctor> _doctors;

        public ResourcesDepartment()
        {
            _doctors = new List<Doctor>();
        }
        public List<Doctor> GetDoctors()
        {
            return _doctors;            
        }
        public Doctor AddDoctor(string name)
        {
            Doctor newDoctor = new Doctor(name);
            _doctors.Add(newDoctor);
            return newDoctor;
        }
        public bool DeleteDoctor(Guid id)
        {
            _doctors.RemoveAll(doctor => doctor.GetId().Equals(id));
            return true;
        }
        public bool EditDoctorDetails(Guid doctorId, string newName)
        {
            _doctors.Find(doctor => doctor.GetId().Equals(doctorId)).UpdateDetails(newName);
            return true;
        }
        public Doctor ChooseDoctorForAppointment()
        {
            Doctor mostAvailableDoctor=null;
            if (_doctors.Any(doctor => doctor.GetAppointmentsCount() == 0))
            { 
            return _doctors.First(doctor => doctor.GetAppointmentsCount() == 0); }
            foreach (var doctor in _doctors)
            {
                if (mostAvailableDoctor==null)
                {
                    mostAvailableDoctor = doctor;
                }
                if (mostAvailableDoctor.GetAppointmentsCount() > doctor.GetAppointmentsCount())
                {
                    mostAvailableDoctor = doctor;
                }
            }
            return mostAvailableDoctor;
        }

    }
}
