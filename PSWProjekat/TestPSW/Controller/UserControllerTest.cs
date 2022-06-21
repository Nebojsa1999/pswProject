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
    public class UserControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        ILogger<UserService>  _logger;
        RegisterDTO registerDTO = new RegisterDTO();
        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig,_logger);
            registerDTO.Address = "Dusana petrovica 7";
            registerDTO.Email = "test@gmail.com";
            registerDTO.Gender = "0";
            registerDTO.Name = "Marjan";
            registerDTO.Password = "123";
            registerDTO.PhoneNumber = "0631221";
            registerDTO.Surname = "Marjanovic";
            registerDTO.Username = "marjan";
        }

        [Test]
        public void Test1()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetAll();
            Assert.NotNull(users);

        }
        [Test]
        public void Test2()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetBlockedUsers();
            Assert.NotNull(users);

        }
        [Test]
        public void Test3()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetDoctors();
            Assert.NotNull(users);

        }
        [Test]
        public void Test4()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.Register(registerDTO);
            Assert.NotNull(users);

        }
        [Test]
        public void Test5()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetPatients();
            Assert.NotNull(users);

        }
        [Test]
        public void Test6()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.GetPotentialSpammer();
            Assert.NotNull(users);

        }
        [Test]
        public void Test7()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.Block(20002);
            Assert.NotNull(users);

        }
        [Test]
        public void Test8()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.Unblock(20002);
            Assert.NotNull(users);

        }
        [Test]
        public void Test9()
        {
            UserController userController = new UserController(projConfig, userService);
            IActionResult users = userController.RemoveFromSpammerList(20002);
            Assert.NotNull(users);

        }
    }
}
