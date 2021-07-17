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
    [Route("tests")]
    public class TestsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PostsController> _logger;

        public Database Database { get; private set; }

        public TestsController(ILogger<PostsController> logger, Database database)
        {
            _logger = logger;
            this.Database = database;
        }

        [HttpGet]
        public async Task<List<Test>> GetAsync()
        {
            /*
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Test
            {
                Id = rng.Next(0, 10000),
                Name = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
            */

            return await Database.GetTestsAsync();

        }
    }
}
