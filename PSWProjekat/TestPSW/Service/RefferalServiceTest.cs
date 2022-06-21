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
    public class RefferalServiceTest
    {
        ILogger<RefferalService> _logger;
        ProjectConfiguration projConfig;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            RefferalService refferalService = new RefferalService(projConfig, _logger);
            List<Refferal> refferals = refferalService.getAll() as List<Refferal>;
            Assert.NotNull(refferals);
        }

       
    }
}
