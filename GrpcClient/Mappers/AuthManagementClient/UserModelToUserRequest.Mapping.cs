using GrpcClient.Models;
using GrpcService1;

namespace GrpcClient.Mappers.AuthManagementClient
{
    public static class UserModelToUserRequest
    {
        public static UserRequest MapUserModelToUserRequest(UserModel userModel)
        {
            return new UserRequest
            {
                Username = userModel.Username,
                Email = userModel.Email,
                Password = userModel.Password,
            };
        }
    }
}
