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
    public class PharmacyService : BaseService<Pharmacy>,IPharmacyService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly ILogger _logger;
        public PharmacyService(ProjectConfiguration configuration, ILogger<PharmacyService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IEnumerable<Pharmacy> getAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext()))     
            {
                return unitOfWork.Phamracies.GetAll();
            }
        }

    }
}
