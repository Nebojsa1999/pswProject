using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Models.Enums;
using PSWProjekat.Service;
using PSWProjekat.Service.Core;
using PSWProjekat.Util;

namespace PSWProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {

        private IUserService userService;

        public UserController(ProjectConfiguration config, IUserService userService) : base(config, userService)
        {
            this.userService = userService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetAllUsers());
        }
        [Route("doctors")]
        [HttpGet]

        public IActionResult GetDoctors()
        {
            return Ok(userService.GetAllDoctors());
        }

        [Route("register")]
        [HttpPost]

        public IActionResult Register(RegisterDTO registerDTO)
        {
            User user = new User();
            if (userService.GetUserWithEmail(registerDTO.Email) != null)
            {
                return BadRequest("Email address already exists");
            }
            user.Address = registerDTO.Address;
            user.Email = registerDTO.Email;
            user.Password = registerDTO.Password;
            user.Name = registerDTO.Name;
            user.Surname = registerDTO.Surname;
            user.PhoneNumber = registerDTO.PhoneNumber;
            user.Username = registerDTO.Username;
            user.Gender = EnumParse.genderString(registerDTO.Gender);
            return Ok(userService.Add(user));
        }

        [Route("patients")]
        [HttpGet]

        public IActionResult GetPatients()
        {
            return Ok(userService.GetAllPatients());
        }

        [Route("getPotentialSpammer")]
        [HttpGet]
        public IActionResult GetPotentialSpammer()
        {
            return Ok(userService.GetPotentialSpammer());
        }

        [Route("getBlockedUsers")]
        [HttpGet]
        public IActionResult GetBlockedUsers()
        {
            return Ok(userService.GetBlockedUsers());
        }

        [Route("unblock/{id}")]
        [HttpPut]
        public IActionResult Unblock(long id)
        {
            return Ok(userService.Unblock(id));
        }
        [Route("block/{id}")]
        [HttpPut]
        public IActionResult Block(long id)
        {
            return Ok(userService.Block(id));
        }
        [Route("removeFromSpammerList/{id}")]
        [HttpPut]
        public IActionResult RemoveFromSpammerList(long id)
        {
            return Ok(userService.RemoveFromSpammers(id));
        }

    }
}
