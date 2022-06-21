using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSWProjekat.Models.DTO
{
    public class RegisterDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

    }
}
