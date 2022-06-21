using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Medicines : Entity
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string countryProducer { get; set; }
        public string note { get; set; }
    }
}
