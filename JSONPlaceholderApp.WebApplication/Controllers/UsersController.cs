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

        public Repository Database { get; private set; }

        public UsersController(ILogger<UsersController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }
        /*
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
        */

        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
 
            return await Database.AsyncConnection.Table<User>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<User> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<User>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] User value)
        {
            //_UserRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] User value)
        {
            //_UserRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_UserRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<User>(id);
        }
    }
}
