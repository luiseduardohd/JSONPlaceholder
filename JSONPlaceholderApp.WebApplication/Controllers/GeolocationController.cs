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
    [Route("geolocation")]
    public class GeolocationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GeolocationController> _logger;

        //public Repository Database { get; private set; }

        //public GeolocationController(ILogger<GeolocationController> logger, Repository database)
        public GeolocationController(ILogger<GeolocationController> logger)
        {
            _logger = logger;
            //this.Database = database;
        }

        
        [HttpGet]
        public IEnumerable<Geolocation> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Geolocation
            {
                //Id = rng.Next(0, 10000),
                Latitude = Summaries[rng.Next(Summaries.Length)],
                Longitude = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        /*
        [HttpGet]
        public async Task<List<Geolocation>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Geolocation>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Geolocation> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Geolocation>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Geolocation value)
        {
            //_GeolocationRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Geolocation value)
        {
            //_GeolocationRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_GeolocationRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Geolocation>(id);
        }
        */

    }
}
