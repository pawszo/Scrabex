using Microsoft.AspNetCore.Mvc;
using Scrapex.Application.Services;
using Scrapex.News.Application.Models;

namespace Scrapex.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly ILogger<NewsController> _logger;
        private readonly IMediaService _mediaService;

        public NewsController(ILogger<NewsController> logger, IMediaService mediaService)
        {
            _logger = logger;
            _mediaService = mediaService;
        }

        [HttpGet(Name = "GetTodaysNews")]
        public IEnumerable<IReport> Get()
        {

            /*    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            */
            return null;
        }
    }
}