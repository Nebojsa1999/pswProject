using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Repository;

namespace TestPSW.Repository
{
    public class ExaminationRepoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Examination> examination = unitOfWork.Examinations.GetAll() as List<Examination>;
                Assert.AreEqual(examination.Count, 1);

            }
        }

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Examination examination = unitOfWork.Examinations.Get(1);
                Assert.NotNull(examination);

            }
        }
    }
}
