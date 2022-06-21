using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Core;
using PSWProjekat.Models;
using PSWProjekat.Models.Enums;

namespace PSWProjekat.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {

        }

        public User GetUserWithEmail(string email)
        {
            return ProjectContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }


        public IEnumerable<User> GetDoctor()
        {
            List<User> list = new List<User>();
            foreach (Entity entity in ProjectContext.Users.Where(x=>x.Deleted == false && x.UserType == UserType.Doctor_General_Practioner))
            {
                list.Add((User)entity);
            }

            return list;
        }
        public IEnumerable<User> GetPatient()
        {
            List<User> list = new List<User>();
            foreach (Entity entity in ProjectContext.Users.Where(x => x.Deleted == false && x.UserType == UserType.Patient))
            {
                list.Add((User)entity);
            }

            return list;
        }

        public IEnumerable<User> GetPotentialSpammer()
        {
            
            List<User> list = new List<User>();
            foreach (Entity entity in ProjectContext.Users.Where(x => x.Deleted == false && x.PotentialSpammer == true))
            {
                list.Add((User)entity);
            }

            return list;
        }

        public IEnumerable<User> GetBlockedUsers()
        {

            List<User> list = new List<User>();
            foreach (Entity entity in ProjectContext.Users.Where(x => x.Deleted == false && x.Enabled == false))
            {
                list.Add((User)entity);
            }

            return list;
        }





    }


}