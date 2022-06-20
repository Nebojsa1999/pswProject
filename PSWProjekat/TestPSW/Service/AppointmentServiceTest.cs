using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class AppointmentServiceTest
    {

        ILogger<AppointmentService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            AppointmentService appointmentService = new AppointmentService(projConfig, _logger);
            List<Appointment> appointments = appointmentService.getAll() as List<Appointment>;
            Assert.AreEqual(appointments.Count, 1);
        }

        public void Test2()
        {
            AppointmentService appointmentService = new AppointmentService(projConfig, _logger);
            Appointment appointments = appointmentService.Get(1);
            Assert.NotNull(appointments);
        }
    }
}
