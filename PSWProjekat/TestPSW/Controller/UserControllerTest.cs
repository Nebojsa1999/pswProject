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
    public class UserControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        ILogger<UserService>  _logger;
        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig,_logger);
        }

        [Test]
        public void Test1()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetAll();
            Assert.NotNull(users);

        }
    }
}
