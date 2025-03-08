using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AbstractLayer.Core
{
    public class  CallContextBase
    {
        public CallContextBase(IGrpcOperation grpcOperation)
        {
            SetCallContext(grpcOperation);
        }

        public CallContextBase()
        {

        }

        private System.Threading.AsyncLocal<IGrpcOperation> CurrentCallContext = new System.Threading.AsyncLocal<IGrpcOperation>();

        public static CallContextBase Current
        {
            get
            {
                return new CallContextBase();
            }

        }

        private void SetCallContext(IGrpcOperation grpcOperation)
        {
            CurrentCallContext.Value = grpcOperation;
        }

        public IGrpcOperation GetCallContext()
        {
            return CurrentCallContext.Value;
        }

    }



    public interface IGrpcOperation
    {
        string Token { get; set; }
        ApiType ApiType { get; set; }
        string DataBaseName { get; set; }
    }


    public enum ApiType
    {
        AuthApiType,
        ClientWebApiType,
        WebApiType
    }

    public class CallContextFromClient: CallContextBase
    {
        public CallContextFromClient(IGrpcOperation grpcOperation):base(grpcOperation)
        {
            AuthorizationClientWeb(grpcOperation.Token);
        }

        private void AuthorizationClientWeb(string token)
        {

            throw new Exception("");
        }
    }
    
    public class CallContextFromWebApi: CallContextBase
    {
        public CallContextFromWebApi(IGrpcOperation grpcOperation) : base(grpcOperation)
        {
            AuthorizationWebApi(grpcOperation.Token);
        }
        private void AuthorizationWebApi(string token)
        {

            throw new Exception("");
        }
    }
}
