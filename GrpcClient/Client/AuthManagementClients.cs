using ContractsGrpc.CodeGeneration.AuthManagement;

namespace GrpcService1
{
    public static partial class AuthManagement
    {
        public partial class AuthManagementClient : IAuthManagementServices
        {
            public UserReply SignIn(UserRequest request)
            {
                var userReply = SignIn_Grpc(request);

                return userReply;
            }
        }
    }


    //public abstract class A<In, Out>
    //{
        
    //    public void sayHello(In request)
    //    {
    //        OnRun(request);
    //    }
    //    public abstract Out OnRun(In request);

    //}

    //public interface IB1
    //{

    //} 
    
    //public interface IB2
    //{

    //}

    //public class B1 : IB1, A<UserRequest, UserReply>
    //{
    //    public override UserReply OnRun(UserRequest request)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class B2 : IB2, A<TicketRequest, TicketReply>
    //{
       
    //    public override TicketReply OnRun(TicketRequest request)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}


    //public class UserRequest
    //{

    //}
    //public class UserReply
    //{

    //} 
    
    //public class TicketRequest
    //{

    //}
    //public class TicketReply
    //{

    //}
}
