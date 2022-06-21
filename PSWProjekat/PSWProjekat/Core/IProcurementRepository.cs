using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Core
{
    public interface IProcurementRepository : IBaseRepository<Procurement>
    {
        public Procurement GetProcurementBasedOnMedicine(long medicineId);
    }
}
