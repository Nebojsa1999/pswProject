using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
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

        [HttpPost]
        [Route("getMedicines")]
        public IActionResult GetMedicines(ProcurementDTO procurementDTO)
        {
            try
            {
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new ProcurementGRPC.ProcurementGRPCClient(channel);
                long Id = procurementDTO.Id;
                int Amount = procurementDTO.Amount;
                ProcurementRequest request = new ProcurementRequest() { Id = Id ,Amount = Amount };
                ProcurementResponse response = client.GetProcurement(request);
                Procurement procurement = procrumentService.Get(request.Id);
                procurement.Amount = procurement.Amount + request.Amount;
                procrumentService.Update(procurement.Id, procurement);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest("Cannot insert choose a different amount");
            }
        }
    }
}
