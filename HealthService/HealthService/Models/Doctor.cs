﻿using HealthService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Models
{
    class Doctor : IObserver<Appointment>
    {
        private Guid _id;
        private string _name;
        private List<Appointment> _appointments;

        public Doctor()
        {

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
