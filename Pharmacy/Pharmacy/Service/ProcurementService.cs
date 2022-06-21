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
    public class ProcurementService : BaseService<Procurement>, IProcurementService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public ProcurementService(ProjectConfiguration configuration, ILogger<ProcurementService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}
