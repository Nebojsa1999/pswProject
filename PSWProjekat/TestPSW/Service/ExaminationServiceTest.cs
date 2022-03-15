using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class ExaminationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            ExaminationService examinationService = new ExaminationService();
            List<Examination> examinations = examinationService.getAll() as List<Examination>;
            Assert.AreEqual(examinations.Count, 1);
        }

        public void Test2()
        {
            ExaminationService examinationService = new ExaminationService();
            Examination examination = examinationService.Get(1);
            Assert.NotNull(examination);
        }
    }
}
