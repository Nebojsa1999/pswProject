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
    public class ExaminationControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IExaminationService examinationService;
        ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            examinationService = new ExaminationService();
        }

        [Test]
        public void Test1()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.GetAll();
            Assert.NotNull(examinations);

        }
    }
}
