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
    public class PharmacyRepoTest
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
                List<Pharmacy> pharmacy = unitOfWork.Phamracies.GetAll() as List<Pharmacy>;
                Assert.AreEqual(pharmacy.Count, 1);

            }
        }

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Pharmacy pharmacy = unitOfWork.Phamracies.Get(1);
                Assert.NotNull(pharmacy);

            }
        }
    }
}
