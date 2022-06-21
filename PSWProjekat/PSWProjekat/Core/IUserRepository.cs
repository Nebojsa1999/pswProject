using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithEmail(string email);
        IEnumerable<User> GetDoctor();
        public IEnumerable<User> GetPatient();
        public IEnumerable<User> GetPotentialSpammer();
        public IEnumerable<User> GetBlockedUsers();

    }

}