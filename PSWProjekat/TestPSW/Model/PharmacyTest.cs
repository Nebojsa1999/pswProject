using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class PharmacyTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Pharmacy pharmacy = new Pharmacy();
            pharmacy.Address = "testAddress";
            pharmacy.DateCreated = DateTime.MaxValue;
            pharmacy.DateUpdated = DateTime.MaxValue;
            pharmacy.Deleted = false;
            pharmacy.Id = 1;
            pharmacy.Name = "testName";
            pharmacy.Email = "testEmail";
            pharmacy.PhoneNumber = "testPhoneNumber";
            
            Assert.AreEqual(pharmacy.Address, "testAddress");
            Assert.AreEqual(pharmacy.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(pharmacy.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(pharmacy.Deleted, false);
            Assert.AreEqual(pharmacy.Id, 1);
            Assert.AreEqual(pharmacy.Name, "testName");
            Assert.AreEqual(pharmacy.Email, "testEmail");
            Assert.AreEqual(pharmacy.PhoneNumber, "testPhoneNumber");
        
        }
    }
}
