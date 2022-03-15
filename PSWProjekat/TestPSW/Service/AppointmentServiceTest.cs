using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class AppointmentServiceTest
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = appointmentService.getAll() as List<Appointment>;
            Assert.AreEqual(appointments.Count, 1);
        }

        public void Test2()
        {
            AppointmentService appointmentService = new AppointmentService();
            Appointment appointments = appointmentService.Get(1);
            Assert.NotNull(appointments);
        }
    }
}
