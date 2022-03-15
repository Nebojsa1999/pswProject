using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class RefferalServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            RefferalService refferalService = new RefferalService();
            List<Refferal> refferals = refferalService.getAll() as List<Refferal>;
            Assert.AreEqual(refferals.Count, 1);
        }

        public void Test2()
        {
            RefferalService refferalService = new RefferalService();
            Refferal refferal = refferalService.Get(1);
            Assert.NotNull(refferal);
        }
    }
}
