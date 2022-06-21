using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class PrescriptionMedicineRepository : BaseRepository<PrescriptionMedicine>, IPrescriptionMedicineRepository
    {
        public PrescriptionMedicineRepository(ProjectContext context) : base(context)
        {

        }
    }
}
