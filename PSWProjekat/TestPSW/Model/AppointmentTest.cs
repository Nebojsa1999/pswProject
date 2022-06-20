using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class AppointmentTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Appointment appointment = new Appointment();
            Hospital hospital = new Hospital();
            User userDoctor = new User();
            hospital.Id = 1;
            userDoctor.Id = 1;
            appointment.AppointmentDate = DateTime.MaxValue;
            appointment.AppointmentTime = TimeSpan.MaxValue;
            appointment.Hospital = hospital;
            appointment.DateCreated = DateTime.MaxValue;
            appointment.DateUpdated = DateTime.MaxValue;
            appointment.Deleted = false;
            appointment.Id = 1;
            appointment.UserDoctor = userDoctor;

            Assert.AreEqual(appointment.AppointmentDate, DateTime.MaxValue);
            Assert.AreEqual(appointment.AppointmentTime, DateTime.MaxValue);
            Assert.AreEqual(appointment.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(appointment.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(appointment.Deleted, false);
            Assert.AreEqual(appointment.Id, 1);
            Assert.AreEqual(appointment.Hospital.Id,hospital.Id);
            Assert.AreEqual(appointment.UserDoctor.Id, userDoctor.Id);


        }
    }
}
