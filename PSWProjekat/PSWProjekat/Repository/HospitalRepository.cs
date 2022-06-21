using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
      

        public HospitalRepository(ProjectContext context) : base(context)
        {

        }
    }
}
