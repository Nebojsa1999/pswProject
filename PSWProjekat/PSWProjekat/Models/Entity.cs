using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models
{
    public class Entity
    {
        public bool Deleted { get; set; }

        public long Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

    }
}
