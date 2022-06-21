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
using PSWProjekat.Models.DTO;
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
        ILogger<AppointmentService> _applogger;
        AppointmentDTO appointmentDTO = new AppointmentDTO();


        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            appointmentService = new AppointmentService(projConfig,_applogger);
            appointmentDTO.DateBegin = DateTime.Now.ToString();
            appointmentDTO.DateEnd = DateTime.Now.AddDays(10).ToString();
            appointmentDTO.Priority = "0";
            appointmentDTO.Doctor = 4;
        }

        [Test]
        public void Test1()
        {
            AppointmentController appointmentController = new AppointmentController(projConfig, userService, appointmentService);
            IActionResult appointments = appointmentController.GetAll();
            Assert.NotNull(appointments);

        }
        [Test]
        public void Test2()
        {
            AppointmentController appointmentController = new AppointmentController(projConfig, userService, appointmentService);
            IActionResult appointments = appointmentController.GetAppointment(appointmentDTO);
            Assert.NotNull(appointments);

        }
        [Test]
        public void Test3()
        {
            AppointmentController appointmentController = new AppointmentController(projConfig, userService, appointmentService);
            IActionResult appointments = appointmentController.GetAppointmentsSpecialist();
            Assert.NotNull(appointments);
        }
    }
}
