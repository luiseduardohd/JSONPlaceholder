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
    [Route("albums")]
    public class AlbumsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PostsController> _logger;

        public Repository Database { get; private set; }

        public AlbumsController(ILogger<PostsController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }
        /*
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Album
            {
                Id = rng.Next(0, 10000),
                UserId = rng.Next(0, 10000),
                Title = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
        }
        */

        [HttpGet]
        public async Task<List<Album>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Album>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Album> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Album>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Album value)
        {
            //_AlbumRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Album value)
        {
            //_AlbumRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_AlbumRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Album>(id);
        }
    }
}
