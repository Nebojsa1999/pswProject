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
    class AuthControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        ILogger<UserService> _logger;
        LoginDTO loginDTO;
        string email = "test@gmail.com";
        string password = "$2a$12$ovtPDLMjhabIrAOL1xk9fuKBNWBc.Iy821D7t9RTJCeDApQfFZ4Ze";
        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            loginDTO = new LoginDTO();
            loginDTO.Email = email;
            loginDTO.Password = password;
            loginDTO.ClientID = "z68j5pm3s9";
            loginDTO.ClientSecret = "r5h0du3dv1";
        }

        [Test]
        public void Test1()
        {
            AuthController userController = new AuthController(projConfig, userService);
            IActionResult users = userController.Login(loginDTO);
            Assert.NotNull(users);

        }
    }
}
