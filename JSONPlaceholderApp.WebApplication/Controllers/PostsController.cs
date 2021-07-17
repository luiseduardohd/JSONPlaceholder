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
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Post
            {
                Id = rng.Next(0,10000),
                UserId = rng.Next(0, 10000),
                Title = Summaries[rng.Next(Summaries.Length)],
                Body = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
