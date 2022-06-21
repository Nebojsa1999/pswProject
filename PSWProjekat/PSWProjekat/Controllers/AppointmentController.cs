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
    public class AppointmentController : BaseController<Appointment>
    {
        private IAppointmentService appointmentService;
        public  IUserService userService;
        public AppointmentController(ProjectConfiguration config, IUserService userService, IAppointmentService appointmentService) : base(config, userService)
        {
            this.appointmentService = appointmentService;
          
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(appointmentService.getAll());
        }
        [Route("schedule")]
        [HttpPost]
        public IActionResult GetAppointment(AppointmentDTO appointment)
        {
            IEnumerable<Appointment> appointmentList = appointmentService.GetAppointment(appointment);
            List<Appointment> appointmentone = new List<Appointment>();
            if(appointmentList.Count() == 0)
            {
                if(appointment.Priority == "0")
                {
                    IEnumerable<Appointment> appointmentListDoctor = appointmentService.GetAppointmentDoctor(appointment);
                    if(appointmentListDoctor.Count() == 0)
                    {
                        return BadRequest("Sorry couldn't find you a term!");

                    }
                    return Ok(appointmentListDoctor);

                }

                else
                { 
                    IEnumerable<Appointment> appointmentListDate = appointmentService.GetAppointmentDate(appointment);
                    if (appointmentListDate.Count() == 0)
                    {
                        return BadRequest("Sorry couldn't find you a term!");

                    }
                    return Ok(appointmentListDate);

                }
                
             
                
            }
            else
            {
                Appointment appointmentResult = appointmentList.First();
                appointmentone.Add(appointmentResult);
                return Ok(appointmentone);

            }

        }

        [Route("getAppointmentsSpecialists")]
        [HttpGet]
        public IActionResult GetAppointmentsSpecialist()
        {
            return Ok(appointmentService.GetAppointmentSpecialist());
        }




    }
}
