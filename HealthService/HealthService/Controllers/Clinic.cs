﻿using HealthService.Models;
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
        private ClientsDepartment _clientsDepartment;
        private Pharmacy _pharmancy;

        private Action<Appointment> _onAppointmentsCange;
        private Action<Appointment> _onAppointmentDelete;

        public Clinic()
        {
            _calender = new Calendar();
            _resourcesDepartment = new ResourcesDepartment();
            _clientsDepartment = new ClientsDepartment();
            _pharmancy = Pharmacy.GetPharmancy();
            
        }

        public void ListenToAppointmentChanges(Action<Appointment> newListener)
        {
            _onAppointmentsCange += newListener;
        }
        public void ListenToAppointmentDelete (Action<Appointment> newListener)
        {
            _onAppointmentDelete += newListener;
        }


        public List<Patient> GetPatientsFromClientDepartment()
        {
            return _clientsDepartment.GetPatients();
        }
        public List<Doctor> GetDoctorsFromResourceDepartment()
        {
            return _resourcesDepartment.GetDoctors();
        }
        public List<Medicine> GetMedicinesFromPharmancy()
        {
            return _pharmancy.GetMedicines();
        }
        public List<Appointment> GetAppointmentsFromCalandar()
        {
            return _calender.GetAppointments();
        }
        

        public void NewPatient(string patientName)
        {
            Patient newPatient = _clientsDepartment.AddPatient(patientName);
            ListenToAppointmentChanges(newPatient.ChangeAppointments);
            ListenToAppointmentDelete(newPatient.DeleteAppointment);
        }
        public void NewDoctor(string doctorName)
        {
            Doctor newDoctor = _resourcesDepartment.AddDoctor(doctorName);
            ListenToAppointmentChanges(newDoctor.ChangeAppointments);
            ListenToAppointmentDelete(newDoctor.DeleteAppointments);
        }
         public void NewMedicine(string medicineName)
        {
            Medicine newMedicine = _pharmancy.AddMedicine(medicineName);
            ListenToAppointmentChanges(newMedicine.ChangeAppointments);
        }
        public void NewAppointment(Guid patientId)
        {
            Doctor appointmentsDoctor = _resourcesDepartment.ChooseDoctorForAppointment();
            Appointment newAppointment=_calender.AddAppointment(patientId,appointmentsDoctor.GetId());
            _onAppointmentsCange.Invoke(newAppointment);
        }


        public void ChangePatientName(Guid patientId,string newPatientName)
        {
            _clientsDepartment.EditPatientDetails(patientId, newPatientName);
        }
        public void ChangeDoctorName(Guid doctorId, string newDoctorName)
        {
            _resourcesDepartment.EditDoctorDetails(doctorId, newDoctorName);
        }
        public void ChangeAppointment (Guid appointmentId,Guid doctorId, Guid newDoctorId)
        {
            Appointment appointmentAfterEdit= _calender.EditAppointment(appointmentId, doctorId, newDoctorId);
            _onAppointmentsCange.Invoke(appointmentAfterEdit);
        }


        public void DeletePatient(Guid patientId)
        {
            _clientsDepartment.DeletePatient(patientId);
            List<Appointment> appointmentsToDelete= _calender.DeleteAllPatientAppointment(patientId);
            foreach (var appointment in appointmentsToDelete)
            {
                if (appointment.GetStatus().Equals("open"))
                {
                    _onAppointmentDelete.Invoke(appointment);
                }
            }
        public void DeleteDoctor(Guid doctorId)
        {
            // Maybe somday improve the logic by changing all the doctors in those appointments - then the patients will get the change appointment 
            _resourcesDepartment.DeleteDoctor(doctorId);
            List<Appointment> appointmentsToDelete=_calender.DeletAllDoctorsAppointment(doctorId);
            foreach (var appointment in appointmentsToDelete)
            {
                _onAppointmentDelete.Invoke(appointment);
            }
        }
        }
        public void DeleteDoctor(Guid doctorId)
        {
            // Maybe somday improve the logic by changing all the doctors in those appointments - then the patients will get the change appointment 
            _resourcesDepartment.DeleteDoctor(doctorId);
            List<Appointment> appointmentsToDelete = _calender.DeletAllDoctorsAppointment(doctorId);
            foreach (var appointment in appointmentsToDelete)
            {
                _onAppointmentDelete.Invoke(appointment);
            }
        }
        public void DeleteMedicine(Guid medicineId)
        {
            _pharmancy.DeleteMedicine(medicineId);
        }
        public void DelteAppointment(Guid appointmentId)
        {
            Appointment deletedAppointment =_calender.DeleteAppointment(appointmentId);
            _onAppointmentDelete.Invoke(deletedAppointment);
        }

        
    }
}
