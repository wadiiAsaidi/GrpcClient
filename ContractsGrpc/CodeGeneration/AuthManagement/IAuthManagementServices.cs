using System;
using System.Collections.Generic;
using System.Text;

namespace ContractsGrpc.CodeGeneration.AuthManagement
{
    public interface IAuthManagementServices
    {
        GrpcService1.UserReply SignIn(GrpcService1.UserRequest request);
    }
}
