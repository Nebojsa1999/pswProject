using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class ProcurementRepository : BaseRepository<Procurement>, IProcurementRepository
    {
        public ProcurementRepository(ProjectContext context) : base(context)
        {

        }

        public Procurement GetProcurementBasedOnMedicine(long medicineId)
        {
            return ProjectContext.Procurements.Where(x => x.Medicine.Id == medicineId).Include(x => x.Medicine).FirstOrDefault();
        }
    }
}
