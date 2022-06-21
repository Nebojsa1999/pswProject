using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Repository;

namespace TestPSW.Repository
{
    public class UserRepoTest
    {
        string email;
        [SetUp]
        public void Setup()
        {
            email = "nebojsa@gmail.com";
        }

        [Test]
        public void Test1()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<User> user = unitOfWork.Users.GetBlockedUsers() as List<User>;
                Assert.IsTrue(user.Count > 0);

            }
        }


        [Test]
        public void Test2()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<User> user = unitOfWork.Users.GetPotentialSpammer() as List<User>;
                Assert.IsTrue(user.Count > 0);

            }
        }


        [Test]
        public void Test3()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<User> user = unitOfWork.Users.GetDoctor() as List<User>;
                Assert.IsTrue(user.Count > 0);

            }
        }


        [Test]
        public void Test4()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<User> user = unitOfWork.Users.GetPatient() as List<User>;
                Assert.IsTrue(user.Count > 1);

            }
        }


        [Test]
        public void Test5()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {

                User user = unitOfWork.Users.GetUserWithEmail(email);
                Assert.NotNull(user);

            }
        }


    }
}
