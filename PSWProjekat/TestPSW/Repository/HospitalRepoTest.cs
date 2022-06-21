using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PSWProjekat.Core;
using PSWProjekat.Models;
using PSWProjekat.Repository;

namespace TestPSW.Repository
{
    public class HospitalRepoTest
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext())) 
            {
                List<Hospital> hospitals =  unitOfWork.Hospitals.GetAll() as List<Hospital>;

                Assert.AreEqual(hospitals.Count, 1);
            } 
           
        }

      
    }
}
