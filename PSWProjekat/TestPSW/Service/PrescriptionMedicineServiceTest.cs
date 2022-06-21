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
    class PrescriptionMedicineServiceTest
    {
        ILogger<PrescriptionMedicineService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            PrescriptionMedicineService prescriptionMedicineService = new PrescriptionMedicineService(projConfig, _logger);
            PrescriptionMedicine prescriptionMedicines = prescriptionMedicineService.Get(34);
            Assert.NotNull(prescriptionMedicines);
        }
    }
}
