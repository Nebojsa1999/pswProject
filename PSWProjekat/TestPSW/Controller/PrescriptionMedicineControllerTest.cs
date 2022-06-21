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
    class PrescriptionMedicineControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IPrescriptionMedicineService prescriptionMedicineService;
        ILogger<UserService> _logger;
        ILogger<PrescriptionMedicineService> _prelogger;
        PrescriptionDTO prescriptionDTO = new PrescriptionDTO();
        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            prescriptionMedicineService = new PrescriptionMedicineService(projConfig, _prelogger);
            prescriptionDTO.Amount = 5;
            prescriptionDTO.DateOfCreation = DateTime.Now;
            prescriptionDTO.Doctor = "Ana";
            prescriptionDTO.MedicineId = 1;
            prescriptionDTO.PatientUser = "Nebojsa";
        }

        [Test]
        public void Test1()
        {
            PrescriptionMedicineController prescriptionMedicineController = new PrescriptionMedicineController(projConfig, userService, prescriptionMedicineService);
            IActionResult prescriptions = prescriptionMedicineController.MakePrescription(prescriptionDTO);
            Assert.NotNull(prescriptions);

        }
    }
}
