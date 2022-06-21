using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models.DTO
{
    public class PrescriptionDTO
    {
        public string PatientUser { get; set; }
        public string Doctor { get; set; }
        public DateTime DateOfCreation { get; set; }
        public long MedicineId { get; set; }

        public int Amount { get; set; }
    }
}
