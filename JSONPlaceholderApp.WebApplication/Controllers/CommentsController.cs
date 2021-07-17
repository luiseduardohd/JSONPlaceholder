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
    [Route("comments")]
    public class CommentsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ILogger<CommentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Comment
            {
                Id = rng.Next(0, 10000),
                PostId = rng.Next(0, 10000),
                Name = Summaries[rng.Next(Summaries.Length)],
                Email = Summaries[rng.Next(Summaries.Length)],
                Body = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
