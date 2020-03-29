using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Models
{
    class Appointment
    {
        private Guid _id;
        private Guid _doctorId;
        private Guid _patientId;
        private List<Guid> _medicineGiven;
        private string _status;
        public Appointment(Guid doctorId, Guid patientId)
        {
            _id = Guid.NewGuid();
            _doctorId = doctorId;
            _patientId = patientId;
            _medicineGiven = new List<Guid>();
            _status = "Open";
        }
        public bool EndAppointment(List<Guid> medicinesGiven)
        {
            _medicineGiven = medicinesGiven;
            _status = "Ended";
            return true;
        }
        public Guid GetPatientId()
        {
            return _patientId;
        }
        public Guid GetDoctorId()
        {
            return _doctorId;
        }
        public Guid GetId()
        {
            return _id;
        }
    }
}
