using HealthService.Models;
using HealthService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Controllers
{
    class Clinic 
    {
        private Calendar _calender;
        private ResourcesDepartment _resourcesDepartment;
        private ClientsDepartment _clientsDepartment;
        private Pharmacy _pharmancy;

        private Action<Appointment> _onAppointmentsCange;

        public Clinic()
        {
            _calender = new Calendar();
            _resourcesDepartment = new ResourcesDepartment();
            _clientsDepartment = new ClientsDepartment();
            _pharmancy = Pharmacy.GetPharmancy();
            
        }

        public void ListenToAppointmentChanges(Action<Appointment> newListener)
        {
            _onAppointmentsCange += newListener;
        }

        public void NewPatient(string patientName)
        {
            Patient newPatient = _clientsDepartment.AddPatient(patientName);
            ListenToAppointmentChanges(newPatient.ChangeAppointments); 
        }
        public void NewDoctor(string doctorName)
        {
            Doctor newDoctor = _resourcesDepartment.AddDoctor(doctorName);
            ListenToAppointmentChanges(newDoctor.ChangeAppointments);
        }
         public void NewMedicine(string medicineName)
        {
            Medicine newMedicine = _pharmancy.AddMedicine(medicineName);
            ListenToAppointmentChanges(newMedicine.ChangeAppointments);
        }

        public void NewAppointment(Guid patientId)
        {
            Doctor appointmentsDoctor = _resourcesDepartment.ChooseDoctorForAppointment();
            _calender.AddAppointment(patientId,appointmentsDoctor.GetId());
        }
    }
}
