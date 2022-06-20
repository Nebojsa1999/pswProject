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
    public class ExaminationServiceTest
    {
        ILogger<ExaminationService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            ExaminationService examinationService = new ExaminationService(projConfig,_logger);
            List<Examination> examinations = examinationService.GetAllExaminationPastForUser(10002) as List<Examination>;
            Assert.AreEqual(examinations.Count, 1);
        }

        public void Test2()
        {
            ExaminationService examinationService = new ExaminationService(projConfig, _logger);
            
        }
    }
}
