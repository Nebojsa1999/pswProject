using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class PrescriptionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Prescription prescription = new Prescription();
            Medicine medicine = new Medicine();
            User userpatient = new User();
            medicine.Id = 1;
            userpatient.Id = 1;
            prescription.Medicine = medicine;
            prescription.DateCreated = DateTime.MaxValue;
            prescription.DateUpdated = DateTime.MaxValue;
            prescription.Deleted = false;
            prescription.Id = 1;
            prescription.PatientUser = userpatient;

            Assert.AreEqual(prescription.PatientUser.Id, userpatient.Id);
            Assert.AreEqual(prescription.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(prescription.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(prescription.Deleted, false);
            Assert.AreEqual(prescription.Id, 1);
            Assert.AreEqual(prescription.Medicine.Id, medicine.Id);
        }
    }
}
