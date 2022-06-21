using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models.DTO
{
    public class FeedBackDTO
    {
        public string Comment { get; set; }
        public int Grade { get; set; }
        public bool Annonimus { get; set; }
        public long ExaminationId { get; set; }
    }
}
