using Microsoft.AspNetCore.Mvc;

namespace TodoWebAPI.Controllers
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
        WeatherService service;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService svc)
        {
            service = svc;
            _logger = logger;
        }

        /// <summary>
        /// Restituisce 5 previsioni 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else if (id > 10)
            {
                return NotFound();
            }

            var obj = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(obj);
        }

        [HttpGet("asincrona/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WeatherForecast>> GetByIdAsync(int id)
        {
            await Task.Run(() => { });

            if (id <= 0)
            {
                return BadRequest();
            }
            else if (id > 10)
            {
                return NotFound();
            }

            var obj = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(obj);

        }


        [NonAction]
        [HttpPost]
        public IActionResult Create(DateTime d)
        {
            var model = service.Create(d);
            return CreatedAtAction(nameof(Create), model);
        }

        [HttpPost]
        public IActionResult Save(WeatherForecast model)
        {
            return NoContent();
        }

        [NonAction]
        [HttpGet("/Svc")]
        public IActionResult Create([FromQuery] DateTime d, [FromServices] WeatherService svc)
        {
            var model = svc.Create(d);
            return CreatedAtAction(nameof(Create), model);
        }

        [HttpGet("/Test")]
        public IActionResult RedirectTest()
        {
            return RedirectToRoute(new { Controller = "Test", Action = "Index", id = 1 });
        }
    }
}