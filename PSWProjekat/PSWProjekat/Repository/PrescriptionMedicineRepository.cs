using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class PrescriptionMedicineRepository : BaseRepository<PrescriptionMedicine>, IPrescriptionMedicineRepository
    {
        public PrescriptionMedicineRepository(ProjectContext context) : base(context)
        {

        }
    }
}
