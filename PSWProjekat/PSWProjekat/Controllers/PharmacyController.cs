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
    public class PharmacyController : BaseController<Pharmacy>
    {

        private IPharmacyService pharmacyService;

        public PharmacyController(ProjectConfiguration config, IUserService userService, IPharmacyService pharmacyService) : base(config, userService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(pharmacyService.getAll());
        }

   

    }
}
