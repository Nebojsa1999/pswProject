using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models
{
    public class Examination : Entity //pregled
    {
        public Appointment Appointment {get; set;}
        public User User { get; set; } //user moze imati vise appointmenta

    }
}
