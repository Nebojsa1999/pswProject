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
            Assert.NotNull(appointments);
        }

    }
}
