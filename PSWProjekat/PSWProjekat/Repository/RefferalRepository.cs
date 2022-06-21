using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;

namespace PSWProjekat.Repository
{
    public class RefferalRepository : BaseRepository<Refferal>, IRefferalRepository
    {
        public RefferalRepository(ProjectContext context) : base(context)
        {

        }
    }
}
