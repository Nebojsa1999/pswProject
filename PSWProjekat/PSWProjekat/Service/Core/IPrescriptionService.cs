using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Service.Core
{
    public interface IPrescriptionService : IBaseService<Prescription>
    {
        public IEnumerable<Prescription> getAll();

    }
}
