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
    public class MedicineControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IMedicineService medicineService;
        ILogger<UserService> _logger;
        ILogger<MedicineService> _medlogger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            medicineService = new MedicineService(projConfig, _medlogger);
        }

        [Test]
        public void Test1()
        {
            MedicineController medicineController = new MedicineController(projConfig, userService, medicineService);
            IActionResult medicines = medicineController.GetAll();
            Assert.NotNull(medicines);

        }
    }
}
