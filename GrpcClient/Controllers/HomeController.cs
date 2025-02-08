using Grpc.Core;
using GrpcClient.ClientsServices;
using GrpcClient.Mappers.AuthManagementClient;
using GrpcClient.Models;
using GrpcService1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userModel = new UserModel
            {
                Username = "aaaaaaaa",
                Email = "ddd@ff.tn",
                Password = "123"
            };
            SignIn(userModel);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        private void  SignIn(UserModel userModel)
        {
            UserRequest request = UserModelToUserRequest.MapUserModelToUserRequest(userModel);
            //ChannelBase channel;
            //var ssss = new AuthManagement.AuthManagementClient(channel).SignIn(request);
            Services.AuthManagementClient.SignIn(request);
        }

       
    }
}
