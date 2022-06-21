using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models
{
    public class Procurement : Entity 
    {
        public Medicine Medicine { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int Amount { get; set; }
    }
}
