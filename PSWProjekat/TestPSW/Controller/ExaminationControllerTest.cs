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
    public class ExaminationControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IExaminationService examinationService;
        ILogger<UserService> _logger;
        ILogger<ExaminationService> _examlogger;
        ExaminationDTO examinationDTO = new ExaminationDTO();
        ExaminationSpecialistDTO examinationSpecialistDTO = new ExaminationSpecialistDTO();
        CancelDTO cancelDTO = new CancelDTO();

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            examinationService = new ExaminationService(projConfig, _examlogger);
            examinationDTO.appointmentId = 1;
            examinationDTO.userId = 20002;
            examinationSpecialistDTO.appointmentId = 11;
            examinationSpecialistDTO.userId = 20002;
            examinationSpecialistDTO.reason = "Bol u glavi";
            cancelDTO.id = 6;
            cancelDTO.userId = 20002;
        }

        [Test]
        public void Test1()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.GetExaminationPastForUser(10002);
            Assert.NotNull(examinations);

        }
        [Test]
        public void Test2()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.GetExaminationPresentForUser(10002);
            Assert.NotNull(examinations);

        }
        [Test]
        public void Test3()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.GetPatients(4);
            Assert.NotNull(examinations);

        }
        [Test]
        public void Test4()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.ScheduleExamination(examinationDTO);
            Assert.NotNull(examinations);

        }
        [Test]
        public void Test5()
        {
            ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
            IActionResult examinations = examinationController.ScheduleExaminationSpecialist(examinationSpecialistDTO);
            Assert.NotNull(examinations);

        }
        [Test]
        public void Test6()
        { 
         ExaminationController examinationController = new ExaminationController(projConfig, userService, examinationService);
        IActionResult examinations = examinationController.Cancel(cancelDTO);
        Assert.NotNull(examinations);

        }

}
}
