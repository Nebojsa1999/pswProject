using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class ExaminationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Examination examination = new Examination();
            Appointment appointment = new Appointment();
            User user = new User();
            appointment.Id = 1;
            user.Id = 1;
            examination.Appointment = appointment;
            examination.DateCreated = DateTime.MaxValue;
            examination.DateUpdated = DateTime.MaxValue;
            examination.Deleted = false;
            examination.Id = 1;
            examination.User = user;

            Assert.AreEqual(examination.Appointment.Id, appointment.Id);
            Assert.AreEqual(examination.User.Id, user.Id);
            Assert.AreEqual(examination.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(examination.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(examination.Deleted, false);
            Assert.AreEqual(examination.Id, 1);
        }
    }
}
