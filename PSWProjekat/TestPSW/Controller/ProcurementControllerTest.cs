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
    public class ProcurementControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IProcrumentService procrumentService;
        ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            procrumentService = new ProcrumentService();
        }

        [Test]
        public void Test1()
        {
            ProcrumentController procrumentController = new ProcrumentController(projConfig, userService, procrumentService);
            IActionResult procruments = procrumentController.GetAll();
            Assert.NotNull(procruments);

        }
    }
}
