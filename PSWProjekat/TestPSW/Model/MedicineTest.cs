using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class MedicineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Medicine medicine = new Medicine();
            Hospital hospital = new Hospital();
            hospital.Id = 1;
            medicine.Amount = 1;
            medicine.countryProducer = "testCountry";
            medicine.DateCreated = DateTime.MaxValue;
            medicine.DateUpdated = DateTime.MaxValue;
            medicine.Deleted = false;
            medicine.Id = 1;
            medicine.Name = "testName";
            medicine.Hospital = hospital;
            medicine.note = "testNote";
            medicine.Producer = "testProducer";

            Assert.AreEqual(medicine.countryProducer, "testCountry");
            Assert.AreEqual(medicine.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(medicine.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(medicine.Deleted, false);
            Assert.AreEqual(medicine.Id, 1);
            Assert.AreEqual(medicine.Name, "testName");
            Assert.AreEqual(medicine.note, "testNote");
            Assert.AreEqual(medicine.Producer, "testProducer");
            Assert.AreEqual(medicine.Amount, 1);
            Assert.AreEqual(medicine.Hospital.Id, hospital.Id);

        }
    }
}
