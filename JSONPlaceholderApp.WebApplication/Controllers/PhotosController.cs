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

        public PhotosController(ILogger<PhotosController> logger)
        {
            _logger = logger;
        }

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
    }
}
