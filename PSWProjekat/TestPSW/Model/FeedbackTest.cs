using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;

namespace TestPSW.Model
{
    public class FeedbackTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Feedback feedback = new Feedback();
            Examination examination = new Examination();
            User userPatient = new User();
            examination.Id = 1;
            userPatient.Id = 1;
            feedback.Annonimus = false;
            feedback.DateCreated = DateTime.MaxValue;
            feedback.DateUpdated = DateTime.MaxValue;
            feedback.Deleted = false;
            feedback.Id = 1;
            feedback.Comment = "testComment";
            feedback.Examination = examination;
            feedback.Grade = PSWProjekat.Models.Enums.GradeEnum.one;
            feedback.Annonimus = false;

            Assert.AreEqual(feedback.Annonimus, false);
            Assert.AreEqual(feedback.DateCreated, DateTime.MaxValue);
            Assert.AreEqual(feedback.DateUpdated, DateTime.MaxValue);
            Assert.AreEqual(feedback.Deleted, false);
            Assert.AreEqual(feedback.Id, 1);
            Assert.AreEqual(feedback.Comment, "testComment");
            Assert.AreEqual(feedback.Grade, PSWProjekat.Models.Enums.GradeEnum.one);
            Assert.AreEqual(feedback.Examination.Id, examination.Id);

        }
    }
}
