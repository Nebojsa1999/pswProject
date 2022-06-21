using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;
using static ProcurementGRPC;

namespace PSWProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : BaseController<Procurement>
    {

        private IProcurementService procrumentService;
        public ProcurementController(ProjectConfiguration config, IUserService userService, IProcurementService procrumentService) : base(config, userService)
        {
            this.procrumentService = procrumentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(procrumentService.getAll());
        }

        [HttpGet]
        [Route("getMedicines")]
        public IActionResult GetMedicines()
        {
            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new ProcurementGRPC.ProcurementGRPCClient(channel);
                long Id = 1;
                ProcurementRequest request = new ProcurementRequest() { Id = Id };
                ProcurementResponse response = client.GetProcurement(request);

                return Ok(response);
            }
            catch (Exception ex) 
            {
                return Ok();
            }
        }
    }
}
