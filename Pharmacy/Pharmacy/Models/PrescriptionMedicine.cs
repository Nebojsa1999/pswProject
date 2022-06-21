using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class PrescriptionMedicine : Entity
    {
        public Medicines Medicine { get; set; }
        public Prescription Prescription { get; set; }
        public int Amount { get; set; }
    }
}
