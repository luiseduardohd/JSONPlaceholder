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

        public Repository Database { get; private set; }

        public CommentsController(ILogger<CommentsController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }

        /*

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

        */

        [HttpGet]
        public async Task<List<Comment>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Comment>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Comment> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Comment>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Comment value)
        {
            //_CommentRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Comment value)
        {
            //_CommentRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_CommentRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Comment>(id);
        }
    }
}
