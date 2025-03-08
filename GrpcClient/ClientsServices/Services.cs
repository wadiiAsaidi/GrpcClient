using ContractsGrpc.CodeGeneration.AuthManagement;
using Grpc.Core;
using GrpcService1;
using System.Net.Http;
using System.Threading;
using System;
using Grpc.Net.Client;
using Grpc.Core.Interceptors;
using GrpcClient.ClientsServices.GrpcInterceptorClient;

namespace GrpcClient.ClientsServices
{
    public static class Services
    {
        private static CallInvoker ChannelFactory => GetChannel();
        //private static ChannelBase ChannelFactory { get { return GetChannel()} };

        public static IAuthManagementServices AuthManagementClient
        {
            get
            {
                return new AuthManagement.AuthManagementClient(ChannelFactory);
            }
        }


        private static CallInvoker GetChannel()
        {
            string serviceAddress = "https://localhost:5001";
            var handler = new HttpClientHandler();
            var httpClient = new HttpClient(handler) { Timeout = Timeout.InfiniteTimeSpan };

            //    using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var invoker = channel.Intercept(new ClientLoggerInterceptor());


            var channel = GrpcChannel.ForAddress(serviceAddress,
                new GrpcChannelOptions
                {
                    HttpClient = httpClient
                ,
                    UnsafeUseInsecureChannelCallCredentials = true
                });
            var invoker = channel.Intercept(new ClientLoggingInterceptor());
            return invoker;
        }
    }
}
