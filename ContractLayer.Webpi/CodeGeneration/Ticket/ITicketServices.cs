using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement;

namespace ContractLayer.Webpi.CodeGeneration.Ticket
{
    public interface ITicketServices
    {
        TicketReply GetTicket(TicketRequest request);
    }
}
