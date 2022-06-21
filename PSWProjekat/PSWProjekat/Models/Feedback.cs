using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models.Enums;

namespace PSWProjekat.Models
{
    public class Feedback : Entity
    {
        public string Comment { get; set; }
        public GradeEnum Grade { get; set; }
        public bool Annonimus { get; set; }
        public bool IsShown { get; set; }
        public Examination Examination { get; set; }

    }
}
