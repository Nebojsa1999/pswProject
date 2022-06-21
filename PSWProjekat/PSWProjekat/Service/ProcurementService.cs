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
                return unitOfWork.Procruments.GetAll();
            }
        }

    }
}
