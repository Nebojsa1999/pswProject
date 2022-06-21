using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace PSWProjekat.Service.GRPC
{
   
    public class ProcurementGRPCClient
    {
        public ProcurementResponse GetProcurement(long Id,int Amount)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:44357");
            var client = new ProcurementGRPC.ProcurementGRPCClient(channel);

            ProcurementRequest request = new ProcurementRequest() { Id = Id, Amount = Amount };
            ProcurementResponse response = client.GetProcurement(request);

            return response;
        }
    }
}
