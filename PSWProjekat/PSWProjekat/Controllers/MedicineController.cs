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
    public class MedicineController : BaseController<Medicine>
    {

        private IMedicineService medicineService;

        public MedicineController(ProjectConfiguration config, IUserService userService, IMedicineService medicineService) : base(config, userService)
        {
            this.medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(medicineService.getAll());
        }


    }
}
