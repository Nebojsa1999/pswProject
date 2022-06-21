using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Configuration;
using Pharmacy.Models;
using Pharmacy.Service.Core;
using Pharmacy.Service.GRPC;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : BaseController<Procurement>
    {

        private IProcurementService procurementService;
        private ProcurementGRPCService procurementGRPCService;
        public ProcurementController(ProjectConfiguration config, IProcurementService procurementService) : base(config)
        {
            this.procurementService = procurementService;
        }

       // [Route("requestMedicine")]
        //[HttpGet]

//        public IActionResult RequestMedicine()
  //      {
    //        ProcurementRequest request = new ProcurementRequest { Amount = 1, Id = 1 };
      //      return Ok(procurementGRPCService.GetProcurement(request));
        //}

    }
}
