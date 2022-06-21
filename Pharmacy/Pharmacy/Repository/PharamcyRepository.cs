using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Models;
using Pharmacy.Repository.Core;

namespace Pharmacy.Repository
{
    public class PharmacyRepository : BaseRepository<Models.Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(ProjectContext context) : base(context)
        {

        }
    }
}
