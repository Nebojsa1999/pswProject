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
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<User> user = unitOfWork.Users.GetAll() as List<User>;
                Assert.AreEqual(user.Count, 5);

            }
        }

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                User user = unitOfWork.Users.Get(1);
                Assert.NotNull(user);

            }
        }
    }
}
