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
    [Route("addresses")]
    public class AddressesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AddressesController> _logger;

        public Repository Database { get; private set; }

        public AddressesController(ILogger<AddressesController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }

        /*
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Address
            {
                //Id = rng.Next(0, 10000),
                Street = Summaries[rng.Next(Summaries.Length)],
                Suite = Summaries[rng.Next(Summaries.Length)],
                City = Summaries[rng.Next(Summaries.Length)],
                Zipcode = Summaries[rng.Next(Summaries.Length)],
                Geolocation = new Geolocation() { Latitude="Latitude",Longitude="Longitud"},


            })
            .ToArray();
        }
        */

        [HttpGet]
        public async Task<List<Address>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Address>().ToListAsync();

        }

        /*
        [HttpGet("{id}")]
        public async Task<Address> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Address>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Address value)
        {
            //_AddressRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Address value)
        {
            //_AddressRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_AddressRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Address>(id);
        }

        */
    }
}
