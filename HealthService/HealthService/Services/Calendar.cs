using HealthService.Models;
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
        public Appointment AddAppointment(Guid patientID, Guid doctorId)
        {
            Appointment newAppointment = new Appointment(doctorId, patientID);
            _appointments.Add(newAppointment);
            return newAppointment;
        }
        public Appointment DeleteAppointment(Guid appointmentId)
        {
            Appointment appointmentDeleted= _appointments.Find(appointment => appointment.GetId().Equals(appointmentId));
            _appointments.RemoveAll(appointment => appointment.GetId().Equals(appointmentId));
            return appointmentDeleted;
        }

        public Appointment DeletAllDoctorsAppointment(Guid doctorId)
        {
            Appointment appointmentDeleted = _appointments.Find(appointment => appointment.GetDoctorId().Equals(doctorId));
            _appointments.RemoveAll(appointment => appointment.GetDoctorId().Equals(doctorId));
            return appointmentDeleted;
        }
        public Appointment DeleteAllPatientAppointment(Guid patientId)
        {
            Appointment appointmentDeleted = _appointments.Find(appointment => appointment.GetPatientId().Equals(patientId));
            _appointments.RemoveAll(appointment => appointment.GetPatientId().Equals(patientId));

            return appointmentDeleted;
        }
        

        public Appointment EditAppointment(Guid appointmentId, Guid doctorId, Guid newDoctorId)
        {
            Appointment appointmentAfterEdit = _appointments.Find(appointment => appointment.GetId().Equals(appointmentId));
            _appointments.RemoveAll(appointment => appointment.GetId().Equals(appointmentId));
            appointmentAfterEdit.CangeDoctor(newDoctorId);
            _appointments.Add(appointmentAfterEdit);
            return appointmentAfterEdit;
        }


    }
}
