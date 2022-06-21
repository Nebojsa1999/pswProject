using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models.Enums;

namespace PSWProjekat.Models
{
    public class User : Entity
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String ResetPasswordToken { get; set; }
        public String RegistrationToken { get; set; }
        public bool Enabled { get; set;  }
        public bool PotentialSpammer { get; set; }
        public UserType UserType { get; set; }
        public Gender Gender { get; set; }
        public int CancelCount { get; set; }
        public DateTime LastDateOfCancel { get; set; }
    }
}
