using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.WebApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = rng.Next(-20, 55),
    //            Summary = Summaries[rng.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}





    public class ControllerCore: Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }
      
        public override void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
    [ApiController]
    [Route("[controller]")]
    public class TicketController: ControllerCore
    {

        [HttpGet]

        public string GetTicket(int id )
        {

            return "testtttt ok";
        }
    }
}
