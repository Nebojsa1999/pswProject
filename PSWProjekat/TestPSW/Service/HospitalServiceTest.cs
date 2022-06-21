using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Service;

namespace TestPSW.Service
{
    public class HospitalServiceTest
    {
        ILogger<HospitalService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            HospitalService hospitalService = new HospitalService(projConfig, _logger);
            List<Hospital> hospitals = hospitalService.getAll() as List<Hospital>;
            Assert.NotNull(hospitals);
        }

      
    }
}
