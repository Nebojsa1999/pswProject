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
    public class FeedbackControllerTest
    {
        public IUserService userService;
        ProjectConfiguration projConfig;
        public IFeedbackService feedbackService;
        ILogger<UserService> _logger;
        ILogger<FeedbackService> _feedlogger;
        FeedBackDTO feedBackDTO = new FeedBackDTO();

        [SetUp]
        public void Setup()
        {
            projConfig = new ProjectConfiguration();
            userService = new UserService(projConfig, _logger);
            feedbackService = new FeedbackService(projConfig, _feedlogger);
            feedBackDTO.Annonimus = false;
            feedBackDTO.Comment = "Neki komentar";
            feedBackDTO.ExaminationId = 1;
            feedBackDTO.Grade = 4;
        }

        [Test]
        public void Test1()
        {
            FeedbackController feedbackController = new FeedbackController(projConfig, userService, feedbackService);
            IActionResult feedbacks = feedbackController.GetAll();
            Assert.NotNull(feedbacks);

        }
        [Test]
        public void Test2()
        {
            FeedbackController feedbackController = new FeedbackController(projConfig, userService, feedbackService);
            IActionResult feedbacks = feedbackController.GetAllApproved();
            Assert.NotNull(feedbacks);

        }
        [Test]
        public void Test3()
        {
            FeedbackController feedbackController = new FeedbackController(projConfig, userService, feedbackService);
            IActionResult feedbacks = feedbackController.GiveFeedBack(feedBackDTO);
            Assert.NotNull(feedbacks);

        }
        [Test]
        public void Test4()
        {
            FeedbackController feedbackController = new FeedbackController(projConfig, userService, feedbackService);
            IActionResult feedbacks = feedbackController.ChangeFeedbackStatus(1);
            Assert.IsTrue(feedbacks.Equals(true));

        }
       
    }
}
