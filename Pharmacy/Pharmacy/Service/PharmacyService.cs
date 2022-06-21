using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pharmacy.Configuration;
using Pharmacy.Service.Core;

namespace Pharmacy.Service
{
    public class PharmacyService : BaseService<Models.Pharmacy>, IPharmacyService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public PharmacyService(ProjectConfiguration configuration, ILogger<PharmacyService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
    }
}
