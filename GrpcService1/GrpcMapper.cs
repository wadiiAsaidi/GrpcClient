using GrpcService1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GrpcService1
{
    public static class GrpcMapper
    {
        public static  void MapGrpcServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<AuthManagementServices>();
            endpoints.MapGrpcService<GreeterService>();
        }
    }
}
