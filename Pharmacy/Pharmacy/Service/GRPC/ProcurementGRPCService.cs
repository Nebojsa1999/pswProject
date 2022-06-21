using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Pharmacy.Models;
using Pharmacy.Repository;
using Pharmacy.Repository.Core;

namespace Pharmacy.Service.GRPC
{
    public class ProcurementGRPCService : ProcurementGRPC.ProcurementGRPCBase
    {

        public ProcurementGRPCService()
        {
        }

        public override Task<ProcurementResponse> GetProcurement(ProcurementRequest request, ServerCallContext context)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new ProjectContext());
                Procurement procurement = unitOfWork.Procurement.Get(request.Id);

                return Task.FromResult(
                    new ProcurementResponse() { Amount = procurement == null ? 0 : procurement.Amount }
                    ); ;
            }
            catch (Exception e) 
            {
                return Task.FromResult(
                    new ProcurementResponse() { Amount = 0 }
                    ); ;
            }
            
        }
    }
}
