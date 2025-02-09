using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ServicesLayer.Services;
using ServicessLayer.Webapi.Services.Ticket;

namespace GrpcService1
{
    public static class GrpcMapper
    {
        public static  void MapGrpcServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<AuthManagementServices>();
        }

        public static  void MapGrpcServicesWebApi(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<TicketServices>();
        }
    }
}
