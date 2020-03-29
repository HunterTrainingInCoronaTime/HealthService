using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Models
{
    class Patient: IObserver<Appointment>
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
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Appointment value)
        {
            throw new NotImplementedException();
        }
    }
}
