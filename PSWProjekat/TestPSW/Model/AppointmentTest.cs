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
            appointment.AppointmentDate = new DateTime(2022,6,21);
            appointment.AppointmentTime = new TimeSpan(2,14,18);
            appointment.Hospital = hospital;
            appointment.DateCreated = DateTime.Now.Date;
            appointment.DateUpdated = DateTime.Now.Date;
            appointment.Deleted = false;
            appointment.Id = 1;
            appointment.UserDoctor = userDoctor;
           

            Assert.AreEqual(appointment.AppointmentDate, new DateTime(2022, 6, 21));
            Assert.AreEqual(appointment.AppointmentTime, new TimeSpan(2, 14, 18));
            Assert.AreEqual(appointment.DateCreated, DateTime.Now.Date);
            Assert.AreEqual(appointment.DateUpdated, DateTime.Now.Date);
            Assert.AreEqual(appointment.Deleted, false);
            Assert.AreEqual(appointment.Id, 1);
            Assert.AreEqual(appointment.Hospital.Id,hospital.Id);
            Assert.AreEqual(appointment.UserDoctor.Id, userDoctor.Id);


        }
    }
}
