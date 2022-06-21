using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.Enums;
using PSWProjekat.Repository;
using PSWProjekat.Service.Core;
using PSWProjekat.Service;
using PSWProjekat.Util;

namespace PSWProjekat.Service
{
    public class UserService : BaseService<User> , IUserService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;

        public UserService(ProjectConfiguration configuration, ILogger<UserService> logger )
        {
            _logger = logger;
            _configuration = configuration;
        }

   

        public override User Add(User entity)
        {
            if(entity == null)
            {
                return null;
            }
           
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
                entity.Enabled = true;
                entity.UserType = UserType.Patient;
                entity.RegistrationToken = RandomStringHelper.RandomString(20);
                entity.ResetPasswordToken = "";
                entity.DateCreated = DateTime.Now;
                entity.DateUpdated = DateTime.Now;
                unitOfWork.Users.Add(entity);
                _ = unitOfWork.Complete();

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in AddUserMethod {e.Message} {e.StackTrace}");
                return null;
            }

            return entity;
        }       



        public User GetUserWithEmail(string email)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                return unitOfWork.Users.GetUserWithEmail(email);
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in GetUserWithEmailMethod {e.Message } in { e.StackTrace}");
                return null;
            }
        }

       

        public IEnumerable<User> GetAllUsers()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))      
            {
                return unitOfWork.Users.GetAll();
            }
        }

        public IEnumerable<User> GetAllDoctors()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            { 

                return unitOfWork.Users.GetDoctor();

            }
        }
        public IEnumerable<User> GetAllPatients()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {

                return unitOfWork.Users.GetPatient();

            }
        }
                    
        public IEnumerable<User> GetPotentialSpammer()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {

            return unitOfWork.Users.GetPotentialSpammer();

            }
        }

        public IEnumerable<User> GetBlockedUsers()
        {
            using(UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Users.GetBlockedUsers();
            }
        }

        public bool Unblock(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                User user = unitOfWork.Users.Get(id);
                user.Enabled = true;
                user.PotentialSpammer = true;
                unitOfWork.Users.Update(user);
                _ = unitOfWork.Complete();
                return true;  

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in Unblock method {e.Message} in {e.StackTrace}");
                return false;
            }

        }

        public bool Block(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                User user = unitOfWork.Users.Get(id);
                user.Enabled = false;
                user.PotentialSpammer = false;
                unitOfWork.Users.Update(user);
                _ = unitOfWork.Complete();
                return true;

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in Unblock method {e.Message} in {e.StackTrace}");
                return false;
            }

        }

        public bool RemoveFromSpammers(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                User user = unitOfWork.Users.Get(id);
                user.PotentialSpammer = false;
                user.CancelCount = 0;
                unitOfWork.Users.Update(user);
                _ = unitOfWork.Complete();
                return true;

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in UserService in Unblock method {e.Message} in {e.StackTrace}");
                return false;
            }

        }


    }
}
