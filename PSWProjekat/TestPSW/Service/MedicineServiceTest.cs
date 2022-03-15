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
    public class MedicineServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            MedicineService medicineService = new MedicineService();
            List<Medicine> medicines = medicineService.getAll() as List<Medicine>;
            Assert.AreEqual(medicines.Count, 1);
        }

        public void Test2()
        {
            MedicineService medicineService = new MedicineService();
            Medicine medicine = medicineService.Get(1);
            Assert.NotNull(medicine);
        }
    }
}
