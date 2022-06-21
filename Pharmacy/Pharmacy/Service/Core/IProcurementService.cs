using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;

namespace Pharmacy.Service.Core
{
    public interface IProcurementService
    {
        public IEnumerable<Procurement> getAll();

    }
}
