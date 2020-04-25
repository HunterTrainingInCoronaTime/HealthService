﻿using HealthService.Controllers;
using HealthService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Models
{
    class Doctor 
    {
        private Guid _id;
        private string _name;
        private List<Appointment> _appointments;
        Pharmacy _pharmacy;   

        public Doctor(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _appointments = new List<Appointment>();
            _pharmacy = Pharmacy.GetPharmancy();
        }
        public void UpdateDetails(string newName)
        {
            _name = newName;
        }

        public Medicine GivePrescription(Appointment appointment)
        {
            Random rnd= new Random();
            List< Medicine > medicines = _pharmacy.GetMedicines();
            int i = rnd.Next(medicines.Count);
            Medicine medicineGiven = medicines[i];
            return medicineGiven;
        }

        public Guid GetId()
        {
            return _id;
        }

        public void ChangeAppointments(Appointment value)
        {
            if (_appointments.Any(appointment => appointment.GetId().Equals(value.GetId())))
            {
                _appointments.RemoveAll(appointment => appointment.GetId().Equals(value.GetId()));
                _appointments.Add(value);
            }
           
        }
    }
}
