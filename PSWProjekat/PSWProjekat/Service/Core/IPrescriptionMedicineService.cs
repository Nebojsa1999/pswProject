using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;

namespace PSWProjekat.Service.Core
{
    public interface IPrescriptionMedicineService 
    {
        public  Task<PrescriptionMedicine> MakePrescription(PrescriptionDTO entity);
    }
}
