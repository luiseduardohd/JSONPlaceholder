﻿using JSONPlaceholderApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TodosController> _logger;

        public Repository Database { get; private set; }

        public TodosController(ILogger<TodosController> logger, Repository database)
        {
            _logger = logger;
            this.Database = database;
        }

        /*
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Todo
            {
                Id = rng.Next(0, 10000),
                UserId = rng.Next(0, 10000),
                Title = Summaries[rng.Next(Summaries.Length)],
                Completed = Convert.ToBoolean(rng.Next(0, 1)),
            })
            .ToArray();
        }
        */

        [HttpGet]
        public async Task<List<Todo>> GetAsync()
        {

            return await Database.AsyncConnection.Table<Todo>().ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<Todo> GetAsync(long id)
        {
            return await Database.AsyncConnection.Table<Todo>().Where((o) => o.Id == id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Todo value)
        {
            //_TodoRepository.Post(value);
            await Database.AsyncConnection.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task PutAsync(long id, [FromBody] Todo value)
        {
            //_TodoRepository.Put(id, value);
            await Database.AsyncConnection.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //_TodoRepository.Delete(id);
            await Database.AsyncConnection.DeleteAsync<Todo>(id);
        }
    }
}