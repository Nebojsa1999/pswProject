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
    public class HospitalController : BaseController<Hospital>
    {
        private IHospitalService hospitalService;

        public HospitalController(ProjectConfiguration config, IUserService userService, IHospitalService hospitalService) : base(config, userService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hospitalService.getAll());
        }
    }
}
