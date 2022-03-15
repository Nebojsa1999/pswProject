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
using PSWProjekat.Models;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;

namespace TestPSW.Controller
{
    public class HospitalControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IHospitalService hospitalService;
        ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            hospitalService = new HospitalService();
        }

        [Test]
        public void Test1()
        {
            HospitalController hospitalController = new HospitalController(projConfig,userService,hospitalService);
            IActionResult hospitals = hospitalController.GetAll();
            Assert.NotNull(hospitals);

        }
    }
}
