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
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private static readonly string[] Texts = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Id = rng.Next(0, 10000),
                Name = Texts[rng.Next(Texts.Length)],
                Username = Texts[rng.Next(Texts.Length)],
                Email = Texts[rng.Next(Texts.Length)],
                Address = new Address(),
                Phone = Texts[rng.Next(Texts.Length)],
                Website = Texts[rng.Next(Texts.Length)],
                Company = new Company(),
            })
            .ToArray();
        }
    }
}
