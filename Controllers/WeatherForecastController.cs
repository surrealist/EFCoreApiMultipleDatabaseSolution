using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
  // GET domain.com/api/v1/WeatherForecast

  // route value
  // query string
  // header

  [ApiController]
  [Route("api/v1/[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    private readonly App app;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(App app, ILogger<WeatherForecastController> logger)
    {
      this.app = app;
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {  
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = app.ConnectionString,
      })
      .ToArray();
    }
  }
}
