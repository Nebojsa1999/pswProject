using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PSWProjekat.Configuration;
using PSWProjekat.Models;
using PSWProjekat.Repository;
using PSWProjekat.Service.Core;
namespace PSWProjekat.Service
{
    public class MedicineService : BaseService<Medicine>, IMedicineService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public MedicineService(ProjectConfiguration configuration, ILogger<MedicineService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IEnumerable<Medicine> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))       
            {
                return unitOfWork.Medicines.GetAll();
            }
        }

    }
}
