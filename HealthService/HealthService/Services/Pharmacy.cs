using HealthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthService.Services
{
    class Pharmacy
    {
        private static Pharmacy _instance;
        private List<Medicine> _medicines = new List<Medicine>();

        // Lock synchronization object

        private static object syncLock = new object();

        // Constructor (protected)

        protected Pharmacy()
        {
            Medicine Mask = new Medicine("Mask");
            Medicine AlcoGel = new Medicine("AlcoGel");
            Medicine Akamol = new Medicine("Akamol");
            Medicine Nurophen = new Medicine("Nurophen");
            // List of available Medicines
            _medicines.Add(Mask);
            _medicines.Add(AlcoGel);
            _medicines.Add(Akamol);
            _medicines.Add(Nurophen);
            
        }

        public static Pharmacy GetPharmancy()
        {
            // Support multithreaded applications through

            // 'Double checked locking' pattern which (once

            // the instance exists) avoids locking each

            // time the method is invoked

            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Pharmacy();
                    }
                }
            }

            return _instance;
        }

        public List <Medicine> GetMedicines()
        {
            return _medicines;
        }

        public bool AddMedicine(string name)
        {
            Medicine newMedicine = new Medicine(name);
            _medicines.Add(newMedicine);

                return true;
            
        }
        public bool DeleteMedicine(Guid id)
        {
            _medicines.RemoveAll(m => m.GetId().Equals(id));
            return true;
        }

    }
}
