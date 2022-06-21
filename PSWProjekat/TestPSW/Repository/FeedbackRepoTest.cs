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
    public class FeedbackRepoTest
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
                List<Feedback> feedback = unitOfWork.Feedbacks.GetAllApproved() as List<Feedback>;
                Assert.IsTrue(feedback.Count > 0);

            }
        }
        [Test]
        public void Test2()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                List<Feedback> feedback = unitOfWork.Feedbacks.GetAllFeedbacks() as List<Feedback>;
                Assert.NotNull(feedback);

            }
        }

        [Test]
        public void Test3()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                Feedback feedback = unitOfWork.Feedbacks.GetFeedBackBasedOnExam(3);
                Assert.NotNull(feedback);

            }
        }
    }
}
