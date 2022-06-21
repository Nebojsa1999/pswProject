using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class RefferalTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Refferal refferal = new Refferal();
            User doctor = new User();
            Examination examination = new Examination();
            examination.Id = 1;
            doctor.Id = 1;
            refferal.DateCreated = DateTime.MaxValue;
            refferal.DateUpdated = DateTime.MaxValue;
            refferal.Deleted = false;
            refferal.Id = 1;
            refferal.Reason = "testReason";
            refferal.RefferalTime = DateTime.MaxValue;
            refferal.Examination = examination;
           
            Assert.AreEqual(refferal.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(refferal.Examination, examination);
            Assert.AreEqual(refferal.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(refferal.Deleted, false);
            Assert.AreEqual(refferal.Id, 1);
            Assert.AreEqual(refferal.Reason, "testReason");
            Assert.AreEqual(refferal.RefferalTime, DateTime.MaxValue);

        }
    }
}
