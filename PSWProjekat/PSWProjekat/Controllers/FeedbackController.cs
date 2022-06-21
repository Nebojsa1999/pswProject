using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;

namespace PSWProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController<Feedback>
    {
        private IFeedbackService feedbackService;

        public FeedbackController(ProjectConfiguration config, IUserService userService, IFeedbackService feedbackService) : base(config, userService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(feedbackService.getAll());
        }

        [HttpGet]
        [Route("getAllApproved")]
        public IActionResult GetAllApproved()
        {
            return Ok(feedbackService.GetAllApproved());
        }

        [HttpPost]
        [Route("giveFeedback")]
        public IActionResult GiveFeedBack(FeedBackDTO feedbackDTO)
        {
            return Ok(feedbackService.GiveFeedBack(feedbackDTO));
        }
        [HttpPut]
        [Route("changeFeedbackStatus/{id}")]
        public IActionResult ChangeFeedbackStatus(long id)
        {
            return Ok(feedbackService.ChangeFeedbackStatus(id));
        }

    }
}
