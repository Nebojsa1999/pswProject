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
    public class ProcurementRepoTest
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
                List<Procurement> procurement = unitOfWork.Procruments.GetAll() as List<Procurement>;
                Assert.AreEqual(procurement.Count, 1);

            }
        }

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Procurement procurement = unitOfWork.Procruments.Get(1);
                Assert.NotNull(procurement);

            }
        }
    }
}
