using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaloonStudio.Model;

namespace SaloonStudio.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using (var context = new SaloonDbContext())
            {
                context.Database.EnsureCreated();
                var addDepartment = new List<Department>
                {
                    new Department
                    {
                    Id = Guid.NewGuid(),
                    Name = "IT"
                    },
                    new Department
                    {
                    Id = Guid.NewGuid(),
                    Name = "HR"
                    },
                    new Department
                    {
                    Id = Guid.NewGuid(),
                    Name = "Finance"
                    }
                };

                context.AddRange(addDepartment);

                var addEmployee = new List<Employee>
                {
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name="Emamul",
                        DepartmetId = addDepartment.First().Id

                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name ="Atif",
                        DepartmetId = addDepartment.First().Id

                    },
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Name="Athar",
                        DepartmetId = addDepartment.First().Id

                    }
                };

                context.AddRange(addEmployee);
                context.SaveChanges();

            }
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
