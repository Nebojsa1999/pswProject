using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class ProcurementServiceTest
    {
        ILogger<ProcurementService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            ProcurementService procrumentService = new ProcurementService(projConfig,_logger);
            List<Procurement> procurements = procrumentService.getAll() as List<Procurement>;
            Assert.AreEqual(procurements.Count, 1);
        }

        public void Test2()
        {
            ProcurementService procrumentService = new ProcurementService(projConfig, _logger);
            Procurement procurement = procrumentService.Get(1);
            Assert.NotNull(procurement);
        }
    }
}
