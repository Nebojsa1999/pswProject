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
    public class FeedbackServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            FeedbackService feedbackService = new FeedbackService();
            List<Feedback> feedbacks = feedbackService.getAll() as List<Feedback>;
            Assert.AreEqual(feedbacks.Count, 1);
        }

        public void Test2()
        {
            FeedbackService feedbackService = new FeedbackService();
            Feedback feedback = feedbackService.Get(1);
            Assert.NotNull(feedback);
        }
    }
}
