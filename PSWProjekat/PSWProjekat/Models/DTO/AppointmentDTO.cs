using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models.DTO
{
    public class AppointmentDTO
    {
        public long Doctor { get; set; }
        public string DateBegin { get; set; } 
        public string DateEnd { get; set; }
        public string Priority { get; set; }
    }
}
