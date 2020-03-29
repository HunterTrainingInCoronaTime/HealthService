using HealthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Controllers
{
    class Appointment : IObservable<Appointment>
    {
        public IDisposable Subscribe(IObserver<Appointment> observer)
        {
            throw new NotImplementedException();
        }
    }
}
