using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class HospitalTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Hospital hospital = new Hospital();
            hospital.Address = "testAddress";
            hospital.DateCreated = DateTime.MaxValue;
            hospital.DateUpdated = DateTime.MaxValue;
            hospital.Deleted = false;
            hospital.Id = 1;
            hospital.Name = "testName";
            hospital.PhoneNumber = "testPhoneNumber";
            hospital.Email = "testEmail";
            
            Assert.AreEqual(hospital.Address, "testAddress");
            Assert.AreEqual(hospital.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(hospital.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(hospital.Deleted, false);
            Assert.AreEqual(hospital.Id, 1);
            Assert.AreEqual(hospital.Name, "testName");
            Assert.AreEqual(hospital.PhoneNumber, "testPhoneNumber");
            Assert.AreEqual(hospital.Email, "testEmail");

        }
    }
}
