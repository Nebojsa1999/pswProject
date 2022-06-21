using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class PharmacyRepository : BaseRepository<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(ProjectContext context) : base(context)
        {

        }
    }
}
