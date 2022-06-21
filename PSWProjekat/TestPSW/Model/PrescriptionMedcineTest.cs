using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class PrescriptionMedcineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            PrescriptionMedicine prescriptionMedcine = new PrescriptionMedicine();
            Medicine medicine = new Medicine();
            Prescription prescription = new Prescription();
            prescriptionMedcine.Amount = 10;
            prescriptionMedcine.DateCreated = DateTime.MaxValue;
            prescriptionMedcine.DateUpdated = DateTime.MaxValue;
            prescriptionMedcine.Deleted = false;
            prescriptionMedcine.Id = 1;
            medicine.Id = 1;
            prescription.Id = 1;
            prescriptionMedcine.Medicine = medicine; 
            prescriptionMedcine.Prescription = prescription;

            Assert.AreEqual(prescriptionMedcine.Amount, 10);
            Assert.AreEqual(prescriptionMedcine.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(prescriptionMedcine.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(prescriptionMedcine.Deleted, false);
            Assert.AreEqual(prescriptionMedcine.Id, 1);
            Assert.AreEqual(prescriptionMedcine.Medicine, medicine);
            Assert.AreEqual(prescriptionMedcine.Prescription, prescription);

        }
    }
}
