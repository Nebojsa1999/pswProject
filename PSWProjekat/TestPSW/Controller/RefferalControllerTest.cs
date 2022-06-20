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
    public class RefferalControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IRefferalService refferalService;
        ILogger<UserService> _logger;
        ILogger<RefferalService> _refferalLogger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            refferalService = new RefferalService(projConfig, _refferalLogger);
        }

        [Test]
        public void Test1()
        {

            RefferalController refferalController = new RefferalController(projConfig, userService, refferalService);
            IActionResult refferals = refferalController.GetAll();
            Assert.NotNull(refferals);
        }
    }
}
