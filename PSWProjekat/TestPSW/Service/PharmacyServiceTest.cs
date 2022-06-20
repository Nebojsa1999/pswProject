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
    public class PharmacyServiceTest
    {
        ILogger<PharmacyService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            PharmacyService pharmacyService = new PharmacyService(projConfig, _logger);
            List<Pharmacy> pharmacys = pharmacyService.getAll() as List<Pharmacy>;
            Assert.AreEqual(pharmacys.Count, 1);
        }

        public void Test2()
        {
            PharmacyService pharmacyService = new PharmacyService(projConfig, _logger);
            Pharmacy pharmacy = pharmacyService.Get(1);
            Assert.NotNull(pharmacy);
        }
    }
}
