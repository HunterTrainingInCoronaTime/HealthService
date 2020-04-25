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
        private Pharmacy _pharmancy;

        private Action<Appointment> _onAppointmentsCange { set; get; }

        public Clinic()
        {

        }


        public void Listen(Action<Appointment> newListener)
        {
            _onAppointmentsCange += newListener;
        
        }
    }
}
