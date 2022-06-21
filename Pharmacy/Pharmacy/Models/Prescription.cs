using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Prescription: Entity
    {
        public string PatientUser { get; set; }
        public string Doctor { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
