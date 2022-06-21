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
    public class ProcurementService : BaseService<Procurement>, IProcurementService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public ProcurementService(ProjectConfiguration configuration, ILogger<ProcurementService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IEnumerable<Procurement> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))
            {
                return unitOfWork.Procurement.GetAll();
            }
        }
    }
}
