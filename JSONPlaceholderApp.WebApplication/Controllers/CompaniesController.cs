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
    [Route("companies")]
    public class CompaniesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CompaniesController> _logger;

        public CompaniesController(ILogger<CompaniesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Company
            {
                //Id = rng.Next(0, 10000),
                Name = Summaries[rng.Next(Summaries.Length)],
                CatchPhrase = Summaries[rng.Next(Summaries.Length)],
                Bs = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
