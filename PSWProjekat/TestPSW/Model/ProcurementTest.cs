using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class ProcurementTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Procurement procurement = new Procurement();
            Medicine medicine = new Medicine();
            Pharmacy pharmacy = new Pharmacy();
            medicine.Id = 1;
            pharmacy.Id = 1;
            procurement.Medicine = medicine;
            procurement.DateCreated = DateTime.MaxValue;
            procurement.DateUpdated = DateTime.MaxValue;
            procurement.Deleted = false;
            procurement.Id = 1;
            procurement.Pharmacy = pharmacy;
            procurement.Amount = 10;

            Assert.AreEqual(procurement.Amount, 10);
            Assert.AreEqual(procurement.Medicine.Id, medicine.Id);
            Assert.AreEqual(procurement.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(procurement.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(procurement.Deleted, false);
            Assert.AreEqual(procurement.Id, 1);
            Assert.AreEqual(procurement.Pharmacy.Id, pharmacy.Id);
        }
    }
}
