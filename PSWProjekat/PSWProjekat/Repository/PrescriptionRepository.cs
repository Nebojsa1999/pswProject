using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(ProjectContext context) : base(context)
        {

        }
    }
}
