using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class MedicineRepository : BaseRepository<Medicines>, IMedicineRepository
    {
        public MedicineRepository(ProjectContext context) : base(context)
        {

        }
    }
}
