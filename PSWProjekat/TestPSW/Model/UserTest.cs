using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class UserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserDataTest() 
        {
            User user = new User();
            Hospital hospital = new Hospital();
            hospital.Id = 1;
            user.Email = "test@gmail.com";
            user.Username = "test";
            user.Name = "testName";
            user.Surname = "testSurname";
            user.Password = "testPassword";
            user.UserType = PSWProjekat.Models.Enums.UserType.Admin;
            user.RegistrationToken = "";
            user.ResetPasswordToken = "";
            user.Id = 1;
            user.DateCreated = DateTime.MaxValue;
            user.DateUpdated = DateTime.MaxValue;
            user.Deleted = false;
            user.Enabled = false;
            user.Gender = PSWProjekat.Models.Enums.Gender.Male;
            user.PhoneNumber = "testPhoneNumber";
            user.Address = "testAddress";
            user.CancelCount = 4;
            user.LastDateOfCancel = new DateTime(2020, 1, 1);
            user.PotentialSpammer = true;
            Assert.AreEqual(user.CancelCount, 4);
            Assert.AreEqual(user.LastDateOfCancel, new DateTime(2020, 1, 1));
            Assert.AreEqual(user.PotentialSpammer, true);
            Assert.AreEqual(user.Email, "test@gmail.com");
            Assert.AreEqual(user.Username, "test");
            Assert.AreEqual(user.Name, "testName");
            Assert.AreEqual(user.Surname, "testSurname");
            Assert.AreEqual(user.Password, "testPassword");
            Assert.AreEqual(user.Address, "testAddress");
            Assert.AreEqual(user.PhoneNumber, "testPhoneNumber");
            Assert.AreEqual(user.UserType, PSWProjekat.Models.Enums.UserType.Admin);
            Assert.AreEqual(user.Gender, PSWProjekat.Models.Enums.Gender.Male);
            Assert.AreEqual(user.RegistrationToken, "");
            Assert.AreEqual(user.ResetPasswordToken, "");
            Assert.AreEqual(user.Id, 1);
            Assert.AreEqual(user.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(user.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(user.Deleted, false);
            Assert.AreEqual(user.Enabled, false);
        }
    }
}
