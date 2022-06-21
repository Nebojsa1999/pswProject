using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pharmacy.Configuration;
using Pharmacy.Models;
using Pharmacy.Service.Core;

namespace Pharmacy.Service
{
    public class MedicineService : BaseService<Medicines>, IMedicineService
    {

        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public MedicineService(ProjectConfiguration configuration, ILogger<Medicines> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}
