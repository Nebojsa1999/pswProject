using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class ProcurementRepository: BaseRepository<Procurement>, IProcurementRepository
    {
        public ProcurementRepository(ProjectContext context) : base(context)
        {

        }
    }
}
