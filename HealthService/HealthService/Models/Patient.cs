using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Models
{
    class Patient
    {
        private Guid _id;
        private string _name;
        private List<Appointment> _appointments;

        public Patient(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _appointments = new List<Appointment>();
        }
        public void UpdateDetails(string newName)
        {
            _name = newName;
        }

        public Guid GetId()
        {
            return _id;
        }

        public void ChangeAppointments(Appointment changedAppointment)
        {
            if (_appointments.Any(appointment => appointment.GetId().Equals(changedAppointment.GetId())))
            {
                _appointments.RemoveAll(appointment => appointment.GetId().Equals(changedAppointment.GetId()));
                _appointments.Add(changedAppointment);
            }
        }
        public void DeleteAppointment(Appointment appointmentToDelete)
        {
            if (_appointments.Any(appointment => appointment.GetId().Equals(appointmentToDelete.GetId())))
            {
                _appointments.RemoveAll(appointment => appointment.GetId().Equals(appointmentToDelete.GetId()));
            }
        }
    }
}
