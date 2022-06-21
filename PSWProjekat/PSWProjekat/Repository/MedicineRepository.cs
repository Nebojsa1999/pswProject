using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(ProjectContext context) : base(context)
        {

        }
    }
}
