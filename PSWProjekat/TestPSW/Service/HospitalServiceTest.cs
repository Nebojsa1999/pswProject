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
    public class HospitalServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            HospitalService hospitalService = new HospitalService();
            List<Hospital> hospitals = hospitalService.getAll() as List<Hospital>;
            Assert.AreEqual(hospitals.Count, 1);
        }

        public void Test2()
        {
            HospitalService hospitalService = new HospitalService();
            Hospital hospital = hospitalService.Get(1);
            Assert.NotNull(hospital);
        }
    }
}
