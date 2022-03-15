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
    public class PrescriptionControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IPrescriptionService prescriptionService;
        ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            prescriptionService = new PrescriptionService();
        }

        [Test]
        public void Test1()
        {
            PrescriptionController prescriptionController = new PrescriptionController(projConfig, userService, prescriptionService);
            IActionResult prescriptions = prescriptionController.GetAll();
            Assert.NotNull(prescriptions);

        }
    }
}
