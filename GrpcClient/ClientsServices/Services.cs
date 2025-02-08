using ContractsGrpc.CodeGeneration.AuthManagement;
using Grpc.Core;
using GrpcService1;
using System.Net.Http;
using System.Threading;
using System;
using Grpc.Net.Client;

namespace GrpcClient.ClientsServices
{
    public static class Services
    {
        private static ChannelBase ChannelFactory => GetChannel();
        //private static ChannelBase ChannelFactory { get { return GetChannel()} };

        public static IAuthManagementServices AuthManagementClient
        {
            get
            {
                return new AuthManagement.AuthManagementClient(ChannelFactory);
            }
        }


        private static ChannelBase GetChannel()
        {
            string serviceAddress = "https://localhost:5001";
            var handler = new HttpClientHandler();
            var httpClient = new HttpClient(handler) { Timeout = Timeout.InfiniteTimeSpan };

            var channel = GrpcChannel.ForAddress(serviceAddress,
                new GrpcChannelOptions
                {
                    HttpClient = httpClient
                ,
                    UnsafeUseInsecureChannelCallCredentials = true
                });
            return channel;
        }
    }
}
