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
using PSWProjekat.Service;
using PSWProjekat.Service.Core;

namespace TestPSW.Controller
{
    public class FeedbackControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IFeedbackService feedbackService;
        ILogger<UserService> _logger;
        ILogger<FeedbackService> _feedlogger;

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            feedbackService = new FeedbackService(projConfig, _feedlogger);
        }

        [Test]
        public void Test1()
        {
            FeedbackController feedbackController = new FeedbackController(projConfig, userService, feedbackService);
            IActionResult feedbacks = feedbackController.GetAll();
            Assert.NotNull(feedbacks);

        }
    }
}
