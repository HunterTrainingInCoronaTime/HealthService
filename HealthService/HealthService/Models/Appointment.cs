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
        private List<Guid> _medicineGivven;

        public Appointment()
        {

        }
    }
}
