using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(ProjectContext context) : base(context)
        {

        }
    }
}
