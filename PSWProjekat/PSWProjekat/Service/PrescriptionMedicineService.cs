using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Models.DTO;
using PSWProjekat.Repository;
using PSWProjekat.Service.Core;

namespace PSWProjekat.Service
{
    public class PrescriptionMedicineService : BaseService<PrescriptionMedicine>, IPrescriptionMedicineService
    {

        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public PrescriptionMedicineService(ProjectConfiguration configuration, ILogger<PrescriptionMedicineService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public async Task<PrescriptionMedicine> MakePrescription(PrescriptionDTO entity)
        {
            PrescriptionMedicine prescriptionMedicine = new PrescriptionMedicine();
            Prescription prescription = new Prescription();
            Procurement procrument = new Procurement();

            if (entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());

                prescription.DateCreated = DateTime.Now;
                prescription.DateUpdated = DateTime.Now;
                prescription.DateOfCreation = DateTime.Now;
                prescription.Doctor = entity.Doctor;
                prescription.PatientUser = entity.PatientUser;
                prescription.Deleted = false;
                
                unitOfWork.Prescriptions.Add(prescription);
                _ = unitOfWork.Complete();

                prescriptionMedicine.Prescription = unitOfWork.Prescriptions.Get(prescription.Id);
                prescriptionMedicine.Medicine = unitOfWork.Medicines.Get(entity.MedicineId);
                prescriptionMedicine.Amount = entity.Amount;
                prescriptionMedicine.DateCreated = DateTime.Now;
                prescriptionMedicine.DateUpdated = DateTime.Now;
                prescriptionMedicine.Deleted = false;
                procrument = unitOfWork.Procruments.GetProcurementBasedOnMedicine(entity.MedicineId);
                procrument.Amount = procrument.Amount - entity.Amount;
                if(procrument.Amount < 0 )
                {
                    return null;
                }
                unitOfWork.Procruments.Update(procrument);
    
                unitOfWork.PrescriptionMedicine.Add(prescriptionMedicine);
                _ = unitOfWork.Complete();

                string json = JsonConvert.SerializeObject(prescriptionMedicine);
                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("https://localhost:44357/api/prescriptionMedicine/savePrescription", new StringContent(json, Encoding.UTF8, "application/json"));



            }

            catch (Exception e)
            {
                _logger.LogError($"Error in PrescriptionMedicineService in MakePrescription method {e.Message} in {e.StackTrace}");
                return null;
            }

            return prescriptionMedicine;
        }
    }
}
