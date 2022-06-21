using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Service.Core
{
    public interface IMedicineService : IBaseService<Medicine>
    {
        public IEnumerable<Medicine> getAll();

    }
}
