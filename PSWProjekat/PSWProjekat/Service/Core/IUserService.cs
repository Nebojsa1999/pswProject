using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Service.Core
{
    public interface IUserService
    {
        User GetUserWithEmail(string email);
        User Add(User entity);
        public IEnumerable<User> GetAllUsers();  
        IEnumerable<User> GetAllDoctors();
        public IEnumerable<User> GetAllPatients();
        User Get(long Id);
        public IEnumerable<User> GetPotentialSpammer();
        public bool Unblock(long id);
        public bool RemoveFromSpammers(long id);
        public IEnumerable<User> GetBlockedUsers();
        public bool Block(long id);


    }
}
