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
    public class RefferalController : BaseController<Refferal>
    {

        private IRefferalService refferalService;

        public RefferalController(ProjectConfiguration config, IUserService userService, IRefferalService refferalService) : base(config, userService)
        {
            this.refferalService = refferalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(refferalService.getAll());
        }


    }
}
