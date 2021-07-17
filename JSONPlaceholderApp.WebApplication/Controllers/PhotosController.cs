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
    [Route("photos")]
    public class PhotosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PhotosController> _logger;

        public Repository Database { get; private set; }

        public PhotosController(ILogger<PhotosController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }


        /*
        [HttpGet]
        public IEnumerable<Photo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Photo
            {
                Id = rng.Next(0, 10000),
                AlbumId = rng.Next(0, 10000),
                Title = Summaries[rng.Next(Summaries.Length)],
                Url = Summaries[rng.Next(Summaries.Length)],
                ThumbnailUrl = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        */

        [HttpGet]
        public async Task<List<Photo>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Photo>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Photo> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Photo>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Photo value)
        {
            //_PhotoRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Photo value)
        {
            //_PhotoRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_PhotoRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Photo>(id);
        }

    }
}
