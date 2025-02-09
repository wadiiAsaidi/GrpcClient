using ContractLayer.Webpi.CodeGeneration.Ticket;

namespace TicketManagement
{
    public static partial class TicketManagement
    {
        public partial class TicketManagementClient : ITicketServices
        {
            public TicketReply GetTicket(TicketRequest request)
            {
                var reply = GetTicket_Grpc(request);
                return reply;
            }
        }
    }
}
