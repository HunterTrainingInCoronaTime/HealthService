using HealthService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Services
{
    class Calendar
    {
        private List<Appointment> _appointments;

        public Calendar()
        {
            _appointments = new List<Appointment>();
        }
        public List<Appointment> GetAppointments()
        {
            return _appointments;
        }
        public bool AddAppointment(Guid patientID, Guid doctorId)
        {
            return true;
        }
        public bool DeleteAppointment(Guid appointmentId)
        {
            _appointments.RemoveAll(appointment => appointment.GetId().Equals(appointmentId));
            return true;
        }

        public bool DeletAllDoctorsAppointment(Guid doctorId)
        {
            _appointments.RemoveAll(appointment => appointment.GetDoctorId().Equals(doctorId));
            return true;
        }
        public bool DeleteAllPatientAppointment(Guid patientId)
        {
            _appointments.RemoveAll(appointment => appointment.GetPatientId().Equals(patientId));

            return true;
        }
        

        public bool EditAppointment(Guid appointmentId, Guid doctorId, Guid newDoctorId)
        {
            return true;
        }


    }
}
