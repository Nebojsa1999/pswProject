using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models.DTO
{
    public class ExaminationSpecialistDTO
    {
        public long userId { get; set; }
        public long appointmentId { get; set; }
        public string reason { get; set; }
    }
}
