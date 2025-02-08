using ContractsGrpc.CodeGeneration.AuthManagement;
using Grpc.Core;

namespace GrpcService1.Services
{
    public partial class AuthManagementServices : AuthManagement.AuthManagementBase
    {

        public override System.Threading.Tasks.Task<GrpcService1.UserReply> SignIn_Grpc(GrpcService1.UserRequest request, ServerCallContext context)
        {
            var reply = SignIn(request);
            return System.Threading.Tasks.Task.FromResult(reply);
        }
    }


    public partial class AuthManagementServices : IAuthManagementServices
    {
        public UserReply SignIn(UserRequest request)
        {
            throw new System.NotImplementedException();
        }
    }

}
