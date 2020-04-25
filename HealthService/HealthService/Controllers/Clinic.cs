using HealthService.Models;
using HealthService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Controllers
{
    class Clinic : IObservable<Appointment>
    {
        private Calendar _calender;
        private ResourcesDepartment _resourcesDepartment;
        private Pharmacy _pharmancy;

        private List<IObserver<Appointment>> _observers;

        public Clinic()
        {

        }


        public IDisposable Subscribe(IObserver<Appointment> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                List <Appointment> appointments = _calender.GetAppointments();
                _observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in appointments)
                {
                    observer.OnNext(item);
                }
            }

            return new Unsubscriber<Appointment>(_observers, observer);

            /*
            foreach ( _observer in _observers)
            {
                _observer.OnNext(_calender.GetAppointments());
            }
            throw new NotImplementedException();*/
        }
    }
}
