using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Procurement : Entity
    {
        public Medicines Medicine { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int Amount { get; set; }
    }
}
