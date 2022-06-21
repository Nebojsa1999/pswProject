using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models
{
    public class Appointment : Entity
    {
        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public Hospital Hospital { get; set; }

        public User UserDoctor { get; set; }



    }
}
