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
                Procurement procurement = unitOfWork.Procurement.GetProcurement(request.Id);
                procurement.Amount = procurement.Amount - request.Amount;
                if(procurement.Amount >= 0)
                {
                    unitOfWork.Procurement.Update(procurement);
                    _ = unitOfWork.Complete();
                    return Task.FromResult(
                    new ProcurementResponse() { Id = procurement == null ? 0 : procurement.Id, Amount = procurement == null ? 0 : request.Amount }
                    ); ;
                }
                else
                {
                    return Task.FromResult< ProcurementResponse> (null);
                }
                
            }
            catch (Exception e) 
            {
                return Task.FromResult(
                    new ProcurementResponse() {Id = 0, Amount = 0 }
                    ); ;
            }
            
        }
    }
}
