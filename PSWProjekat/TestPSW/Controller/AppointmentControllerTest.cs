using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Controllers;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;

namespace TestPSW.Controller
{
    public class AppointmentControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IAppointmentService appointmentService;
        ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            appointmentService = new AppointmentService();
        }

        [Test]
        public void Test1()
        {
            AppointmentController appointmentController = new AppointmentController(projConfig, userService, appointmentService);
            IActionResult appointments = appointmentController.GetAll();
            Assert.NotNull(appointments);

        }
    }
}
