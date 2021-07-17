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

        public Repository Database { get; private set; }

        public PostsController(ILogger<PostsController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }

        /*
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
        */

        [HttpGet]
        public async Task<List<Post>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Post>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Post> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Post>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Post value)
        {
            //_PostRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Post value)
        {
            //_PostRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_PostRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Post>(id);
        }

    }
}
