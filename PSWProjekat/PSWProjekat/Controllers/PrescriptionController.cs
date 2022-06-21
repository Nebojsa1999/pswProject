using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;

namespace PSWProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : BaseController<Prescription>
    {

        private IPrescriptionService prescriptionService;

        public PrescriptionController(ProjectConfiguration config, IUserService userService, IPrescriptionService prescriptionService) : base(config, userService)
        {
            this.prescriptionService = prescriptionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(prescriptionService.getAll());
        }

       



    }
}
