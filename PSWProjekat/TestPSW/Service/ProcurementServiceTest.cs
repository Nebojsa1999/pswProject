using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class ProcurementServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            ProcrumentService procrumentService = new ProcrumentService();
            List<Procurement> procurements = procrumentService.getAll() as List<Procurement>;
            Assert.AreEqual(procurements.Count, 1);
        }

        public void Test2()
        {
            ProcrumentService procrumentService = new ProcrumentService();
            Procurement procurement = procrumentService.Get(1);
            Assert.NotNull(procurement);
        }
    }
}
