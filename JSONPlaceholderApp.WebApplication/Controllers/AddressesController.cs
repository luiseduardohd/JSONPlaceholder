using JSONPlaceholderApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication.Controllers
{
    [ApiController]
    [Route("addresses")]
    public class AddressesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AddressesController> _logger;

        public AddressesController(ILogger<AddressesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Address> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Address
            {
                //Id = rng.Next(0, 10000),
                Street = Summaries[rng.Next(Summaries.Length)],
                Suite = Summaries[rng.Next(Summaries.Length)],
                City = Summaries[rng.Next(Summaries.Length)],
                Zipcode = Summaries[rng.Next(Summaries.Length)],
                Geolocation = new Geolocation() { Latitude="Latitude",Longitude="Longitud"},


            })
            .ToArray();
        }
    }
}
