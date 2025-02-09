using ContractLayer.Webpi.CodeGeneration.Ticket;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement;

namespace ServicessLayer.Webapi.Services.Ticket
{
    public partial class TicketServices : TicketManagement.TicketManagement.TicketManagementBase
    {
        public override System.Threading.Tasks.Task<TicketManagement.TicketReply> GetTicket_Grpc(TicketManagement.TicketRequest request, ServerCallContext context)
        {
            var reply = GetTicket(request);
            return System.Threading.Tasks.Task.FromResult(reply);
        }
    }

    public partial class TicketServices : ITicketServices
    {
        public TicketReply GetTicket(TicketRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
