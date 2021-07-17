using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //public Repository Database { get; private set; }

        //public WeatherForecastController(ILogger<WeatherForecastController> logger, Repository database)
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            //this.Database = database;
        }

        

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /*

        [HttpGet]
        public async Task<List<WeatherForecast>> GetAsync()
        {

            return await Database.AsyncConnection.Table<WeatherForecast>().ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<WeatherForecast> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<WeatherForecast>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] WeatherForecast value)
        {
            //_WeatherForecastRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] WeatherForecast value)
        {
            //_WeatherForecastRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_WeatherForecastRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<WeatherForecast>(id);
        }

        */

    }
}
