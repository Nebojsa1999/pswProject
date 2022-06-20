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
    public class PharmacyControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IPharmacyService pharmacyService;
        ILogger<UserService> _logger;
        ILogger<PharmacyService> _phamlogger;
        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            pharmacyService = new PharmacyService(projConfig, _phamlogger);
        }

        [Test]
        public void Test1()
        {
            PharmacyController pharmacyController = new PharmacyController(projConfig, userService, pharmacyService);
            IActionResult pharmacies = pharmacyController.GetAll();
            Assert.NotNull(pharmacies);

        }
    }
}
