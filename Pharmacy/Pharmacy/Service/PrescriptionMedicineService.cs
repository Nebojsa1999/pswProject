using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pharmacy.Configuration;
using Pharmacy.Models;
using Pharmacy.Repository;
using Pharmacy.Service.Core;

namespace Pharmacy.Service
{
    public class PrescriptionMedicineService : BaseService<PrescriptionMedicine>, IPrescriptionMedicineService
    {

        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public PrescriptionMedicineService(ProjectConfiguration configuration, ILogger<PrescriptionMedicine> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public override  PrescriptionMedicine Add(PrescriptionMedicine entity)
        {
            if (entity == null)
            {
                return null;
            }
            Prescription prescription = new Prescription();
            PrescriptionMedicine prescriptionMedicine = new PrescriptionMedicine();
            Medicines medicine = new Medicines();
            try
            {
                using UnitOfWork unitOfWork = new(new ProjectContext());
                prescription.DateCreated = entity.Prescription.DateCreated;
                prescription.DateOfCreation = entity.Prescription.DateOfCreation;
                prescription.DateUpdated = entity.Prescription.DateUpdated;
                prescription.Deleted = entity.Prescription.Deleted;
                prescription.Doctor = entity.Prescription.Doctor;
                prescription.PatientUser = entity.Prescription.PatientUser;
                unitOfWork.Prescription.Add(prescription);
                _ = unitOfWork.Complete();

            
                prescriptionMedicine.Amount = entity.Amount;
                prescriptionMedicine.DateCreated = entity.DateCreated;
                prescriptionMedicine.DateUpdated = entity.DateUpdated;
                prescriptionMedicine.Deleted = entity.Deleted;
                prescriptionMedicine.Prescription = unitOfWork.Prescription.Get(prescription.Id);
                medicine = unitOfWork.Medicine.Get(entity.Medicine.Id);
                prescriptionMedicine.Medicine = medicine;
                unitOfWork.PrescriptionMedicine.Add(prescriptionMedicine);
                _ = unitOfWork.Complete();
                System.Diagnostics.Debug.WriteLine(prescriptionMedicine.Amount);

            }

            catch (Exception e)
            {
                _logger.LogError($"Error in PrescriptionMedicineService in Add Method{e.Message} {e.StackTrace}");
                return null;
            }

            return prescriptionMedicine;
        }
    }
}
