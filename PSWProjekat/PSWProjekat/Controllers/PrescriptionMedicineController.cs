﻿using System;
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
    public class PrescriptionMedicineController : BaseController<PrescriptionMedicine>
    {

        private IPrescriptionMedicineService prescriptionmedicineService;

        public PrescriptionMedicineController(ProjectConfiguration config, IUserService userService, IPrescriptionMedicineService prescriptionmedicineService) : base(config, userService)
        {
            this.prescriptionmedicineService = prescriptionmedicineService;
        }

        [Route("makePrescription")]
        [HttpPost]

        public IActionResult MakePrescription(PrescriptionDTO prescriptionDTO)
        {

            return Ok(prescriptionmedicineService.MakePrescription(prescriptionDTO));
        }

    }

}
