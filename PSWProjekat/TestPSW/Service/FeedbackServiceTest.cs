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
    public class FeedbackServiceTest
    {
        ILogger<FeedbackService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            FeedbackService feedbackService = new FeedbackService(projConfig, _logger);
            List<Feedback> feedbacks = feedbackService.getAll() as List<Feedback>;
            Assert.AreEqual(feedbacks.Count, 1);
        }

        public void Test2()
        {
            FeedbackService feedbackService = new FeedbackService(projConfig, _logger);
            Feedback feedback = feedbackService.Get(1);
            Assert.NotNull(feedback);
        }
    }
}
