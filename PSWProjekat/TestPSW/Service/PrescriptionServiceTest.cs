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
    public class PrescriptionServiceTest
    {
        ILogger<PrescriptionService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            PrescriptionService prescriptionService = new PrescriptionService(projConfig, _logger);
            List<Prescription> prescriptions = prescriptionService.getAll() as List<Prescription>;
            Assert.AreEqual(prescriptions.Count, 1);
        }

        public void Test2()
        {
            PrescriptionService prescriptionService = new PrescriptionService(projConfig, _logger);
            Prescription prescription = prescriptionService.Get(1);
            Assert.NotNull(prescription);
        }
    }
}
