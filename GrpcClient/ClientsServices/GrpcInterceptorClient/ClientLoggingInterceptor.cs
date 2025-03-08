using AbstractLayer.Core;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Newtonsoft.Json;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace GrpcClient.ClientsServices.GrpcInterceptorClient
{



    public class ClientLoggingInterceptor: Interceptor
    {
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {

            var header = new Metadata();
            var clientInfo = new GrpcClientInfo
            {
                Token = "aaaaaaa",
                ApiType = ApiType.ClientWebApiType,
                DataBaseName = "DataBaseName"
            };
            header.Add("ClientInfo", JsonConvert.SerializeObject(clientInfo));
            context.Options.WithHeaders(header);
            return continuation(request, context);
        }
    }


    public class GrpcClientInfo : AbstractLayer.Core.IGrpcOperation
    {
        public string Token { get; set; }
        public ApiType ApiType { get; set; }
        public string DataBaseName { get; set; }
    }
}
