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
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Todo
            {
                Id = rng.Next(0, 10000),
                UserId = rng.Next(0, 10000),
                Title = Summaries[rng.Next(Summaries.Length)],
                Completed = Convert.ToBoolean(rng.Next(0, 1)),
            })
            .ToArray();
        }
    }
}
