using BusinessLayer.AuthManagement;
using ContractsGrpc.CodeGeneration.AuthManagement;
using EntitiesLayer.AuthManagement;
using Grpc.Core;
using GrpcService1;
using Microsoft.VisualBasic;
using System;

namespace ServicesLayer.Services
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
        private UserBusiness UserB = new UserBusiness();

        public UserReply SignIn(UserRequest request)
        {
            var user = new User 
            {
                Id = Guid.NewGuid(),
                Username= request.Username,
                Email = request.Email,
                Password = request.Password,

            };
            var token = UserB.SignIn(user);

            return new UserReply
            {
                Token = token
            };

        }
    }

}
