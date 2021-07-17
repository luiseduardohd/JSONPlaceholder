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

        public Repository Database { get; private set; }

        public TestsController(ILogger<PostsController> logger, Repository database)
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

            return await Database.AsyncConnection.Table<Test>().ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<Test> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Test>().Where( (o)=> o.Id == id ).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Test value)
        {
            //_TestRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Test value)
        {
            //_TestRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_TestRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Test>(id);
        }
    }
}
