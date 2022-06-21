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
                List<Examination> examination = unitOfWork.Examinations.GetExaminationsFromDoctor(4) as List<Examination>;
                Assert.IsTrue(examination.Count() > 1);

            }
        }
        [Test]

        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Examination> examination = unitOfWork.Examinations.GetAllExaminationPresentForUser(10002) as List<Examination>;
                Assert.NotNull(examination);

            }
        }

        [Test]

        public void Test3()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Examination> examination = unitOfWork.Examinations.GetAllExaminationsPastForUser(10002) as List<Examination>;
                Assert.NotNull(examination);

            }
        }

        [Test]

        public void Test4()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Examination examination = unitOfWork.Examinations.GetExaminationBasedOnAppID(10);
                Assert.NotNull(examination);

            }
        }

        [Test]

        public void Test5()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Examination examination = unitOfWork.Examinations.GetExamination(2);
                Assert.NotNull(examination);

            }
        }
    }
}
