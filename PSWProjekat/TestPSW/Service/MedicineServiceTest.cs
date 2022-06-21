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

    public class MedicineServiceTest
    {
        ILogger<MedicineService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            MedicineService medicineService = new MedicineService(projConfig, _logger);
            List<Medicine> medicines = medicineService.getAll() as List<Medicine>;
            Assert.AreEqual(medicines.Count, 2);
        }

      
    }
}
