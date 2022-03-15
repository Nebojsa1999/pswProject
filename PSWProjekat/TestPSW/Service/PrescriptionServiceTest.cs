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
    public class PrescriptionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            PrescriptionService prescriptionService = new PrescriptionService();
            List<Prescription> prescriptions = prescriptionService.getAll() as List<Prescription>;
            Assert.AreEqual(prescriptions.Count, 1);
        }

        public void Test2()
        {
            PrescriptionService prescriptionService = new PrescriptionService();
            Prescription prescription = prescriptionService.Get(1);
            Assert.NotNull(prescription);
        }
    }
}
