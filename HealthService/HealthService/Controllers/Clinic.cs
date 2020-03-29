using HealthService.Models;
using HealthService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Controllers
{
    class Appointment : IObservable<Appointment>
    {
        private Calendar _calender;
        private ResourcesDepartment _resourcesDepartment;
        private Pharmacy _pharmancy;

        private List<IObserver<Appointment>> _observers;

        public Appointment()
        {

        }


        public IDisposable Subscribe(IObserver<Appointment> observer)
        {
            throw new NotImplementedException();
        }
    }
}
