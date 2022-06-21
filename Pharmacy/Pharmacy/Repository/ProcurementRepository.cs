using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class ProcurementRepository: BaseRepository<Procurement>, IProcurementRepository
    {
        public ProcurementRepository(ProjectContext context) : base(context)
        {

        }

        public override IEnumerable<Procurement> GetAll()
        {
            return ProjectContext.Procurement.Include(x => x.Medicine).Include(x => x.Pharmacy).ToList();
        }

        public  Procurement GetProcurement(long id)
        {
            return ProjectContext.Procurement.Where(x=>x.Id == id).Include(x => x.Medicine).Include(x => x.Pharmacy).FirstOrDefault();
        }

    }
}
