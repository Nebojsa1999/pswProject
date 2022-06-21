using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models
{
    public class Refferal : Entity
    {
        public Examination Examination { get; set; }
        public DateTime RefferalTime { get; set; }
        public string Reason { get; set; }
    }
}
