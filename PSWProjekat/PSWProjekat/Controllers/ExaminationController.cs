using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Service.Core;

namespace PSWProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : BaseController<Examination>
    {
        private IExaminationService examinationService;

        public ExaminationController(ProjectConfiguration config, IUserService userService, IExaminationService examinationService) : base(config, userService)
        {
            this.examinationService = examinationService;
        }

        [HttpGet]
        [Route("getAllExaminationsUserId/{id}")]

        public IActionResult GetExaminationPresentForUser(long id)
        {
            return Ok(examinationService.GetAllExaminationPresentForUser(id));
        }

        [HttpGet]
        [Route("getAllExaminationsPastUserId/{id}")]
        public IActionResult GetExaminationPastForUser(long id)
        {
            return Ok(examinationService.GetAllExaminationPastForUser(id));
        }

        [HttpPost]
        [Route("scheduleExamination")]
        public IActionResult ScheduleExamination(ExaminationDTO examinationDTO)
        {
            if (examinationService.ScheduleExamination(examinationDTO) == null)
            {
                return BadRequest("This appointment is already scheduled!");
            }
            else
            {
                return Ok(examinationService.ScheduleExamination(examinationDTO));
            }
        }

        [HttpPost]
        [Route("scheduleExaminationSpecialist")]

        public IActionResult ScheduleExaminationSpecialist(ExaminationSpecialistDTO examinationSpecialistDTO)
        {
            if (examinationService.ScheduleExaminationSpecialist(examinationSpecialistDTO) == null)
            {
                return BadRequest("This appointment is already scheduled!");
            }
            else
            {
                return Ok(examinationService.ScheduleExaminationSpecialist(examinationSpecialistDTO));
            }
        }

        [HttpPut]
        [Route("cancel")]
        public IActionResult Cancel(CancelDTO cancelDTO)
        {
            return Ok(examinationService.Cancel(cancelDTO));
        }

        [HttpGet]
        [Route("getPatientsFromExamination/{doctorId}")]
        public IActionResult GetPatients(long doctorId)
        {
            return Ok(examinationService.GetExaminationsFromDoctor(doctorId));
        }
    }
}
