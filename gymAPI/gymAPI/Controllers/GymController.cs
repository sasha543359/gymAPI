using gymAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymController : ControllerBase
    {      
        public static List<Customer> Test()
        {
            return new List<Customer>
            {
                new Customer("Albero", "Rodrigues",18, new CustomerSubscription(Subscription.Basic)),
                new Customer("Cholobei", "Cholobescu",21, new CustomerSubscription(Subscription.Silver)),
                new Customer("montenel", "Muntescu",35, new CustomerSubscription(Subscription.Gold))

            };
        }
        [HttpGet(Name = "Customer")]
        public IEnumerable<Customer> Get()
        {
            //return Enumerable.Range(1, 3).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            return Test();
        }
    }
}
