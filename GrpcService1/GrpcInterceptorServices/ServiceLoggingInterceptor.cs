using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Threading.Tasks;
using System;
using AbstractLayer.Core;
using Newtonsoft.Json;

namespace GrpcService1.GrpcInterceptorServices
{
    public class ServiceLoggingInterceptor :Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
           TRequest request,
           ServerCallContext context,
           UnaryServerMethod<TRequest, TResponse> continuation)
        {
            
            try
            {
                var header =  context.RequestHeaders.Get("ClientInfo").Value;
                var json = JsonConvert.DeserializeObject<GrpcClientInfo>(header);
                CreateCallContextContainer(json);
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void CreateCallContextContainer(GrpcClientInfo clientInfo)
        {
            switch (clientInfo.ApiType)
            {
                case ApiType.AuthApiType:
                    
                    break;
                case ApiType.WebApiType:
                    new AbstractLayer.Core.CallContextFromClient(clientInfo);
                    break;
                case ApiType.ClientWebApiType:
                    new AbstractLayer.Core.CallContextFromWebApi(clientInfo);
                    break;
            }
        }
    }


    public class GrpcClientInfo : AbstractLayer.Core.IGrpcOperation
    {
        public string Token { get ; set ; }
        public ApiType ApiType { get; set; }
        public string DataBaseName { get; set; }
    }
}
