using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class UserServiceTest
    {
        ILogger<UserService> _logger;
        ProjectConfiguration projConfig;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            UserService userService = new UserService(projConfig,_logger);
            List<User> users = userService.GetAllUsers() as List<User>;
            Assert.AreEqual(users.Count, 1);
        }

        public void Test2()
        {
            UserService userService = new UserService(projConfig, _logger);
            User user = userService.Get(1);
            Assert.NotNull(user);
        }
    }
}
