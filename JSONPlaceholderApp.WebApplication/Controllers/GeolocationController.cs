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
    [Route("geolocation")]
    public class GeolocationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GeolocationController> _logger;

        public GeolocationController(ILogger<GeolocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Geolocation> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Geolocation
            {
                //Id = rng.Next(0, 10000),
                Latitude = Summaries[rng.Next(Summaries.Length)],
                Longitude = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
