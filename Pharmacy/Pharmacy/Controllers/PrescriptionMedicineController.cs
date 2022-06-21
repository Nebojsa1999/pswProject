using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Configuration;
using Pharmacy.Models;
using Pharmacy.Service.Core;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionMedicineController : BaseController<PrescriptionMedicine>
    {

        private IPrescriptionMedicineService prescriptionmedicineService;

        public PrescriptionMedicineController(ProjectConfiguration config, IPrescriptionMedicineService prescriptionmedicineService) : base(config)
        {
            this.prescriptionmedicineService = prescriptionmedicineService;
        }

        [Route("savePrescription")]
        [HttpPost]

        public IActionResult MakePrescription(PrescriptionMedicine prescription)
        {

            return Ok(prescriptionmedicineService.Add(prescription));
        }
    }
    }
