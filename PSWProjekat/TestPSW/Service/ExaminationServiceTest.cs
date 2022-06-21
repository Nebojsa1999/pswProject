using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class ExaminationServiceTest
    {
        ILogger<ExaminationService> _logger;
        ProjectConfiguration projConfig;
        CancelDTO cancelDTO = new CancelDTO();
        ExaminationSpecialistDTO examinationSpecialistDTO = new ExaminationSpecialistDTO();
        [SetUp]
        public void Setup()
        {
            examinationSpecialistDTO.appointmentId = 13;
            examinationSpecialistDTO.reason = "Bol u glavi";
            examinationSpecialistDTO.userId = 20002;
            cancelDTO.id = 7;
            cancelDTO.userId = 20002;
        }

        [Test]
        public void Test1()
        {

            ExaminationService examinationService = new ExaminationService(projConfig,_logger);
            List<Examination> examinations = examinationService.GetAllExaminationPastForUser(10002) as List<Examination>;
            Assert.AreEqual(examinations.Count, 1);
        }

        [Test]
        public void CreateExaminationSpecialistDateNowWhichExists()
        {
            ExaminationService examinationService = new ExaminationService(projConfig, _logger);
            Assert.IsTrue(examinationService.ScheduleExaminationSpecialist(examinationSpecialistDTO) == null);
        }

        [Test]
        public void CancelExamination48h()
        {
            ExaminationService examinationService = new ExaminationService(projConfig, _logger);
            Assert.IsFalse(examinationService.Cancel(cancelDTO));
        }
    }
}
