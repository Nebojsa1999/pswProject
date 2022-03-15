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
    public class RefferalRepoTest
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
                List<Refferal> refferal = unitOfWork.Refferals.GetAll() as List<Refferal>;
                Assert.AreEqual(refferal.Count, 1);

            }
        }

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Refferal refferal = unitOfWork.Refferals.Get(1);
                Assert.NotNull(refferal);

            }
        }
    }
}
