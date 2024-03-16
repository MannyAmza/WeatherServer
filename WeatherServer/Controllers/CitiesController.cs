using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountryModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using WeatherServer.DTO;

namespace WeatherServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(CountriesSourceContext context) : ControllerBase
    {

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await context.Cities.ToListAsync();
        }

        [HttpGet("GetPopulation")]
        public async Task<ActionResult<IEnumerable<CountryPopulation>>> GetPopulation()
        {
            IQueryable<CountryPopulation> query = from c in context.Countries
                    select new CountryPopulation
                    {
                        CountryID = c.CountryID,
                        Name = c.Name,
                        //Population = c.City.Sum(testc => testc.Population)
                    };
            return await query.ToListAsync();
        }

        [HttpGet("GetPopulation2")]
        public async Task<ActionResult<IEnumerable<CountryPopulation>>> GetPopulation2()
        {
            IQueryable<CountryPopulation> query = context.Countries.Select(c =>
                                                new CountryPopulation
                                                {
                                                    CountryID = c.CountryID,
                                                    Name = c.Name,
                                                    //Population = c.City.Sum(testc => testc.Population)
                                                });
            return await query.ToListAsync();
        }
    }
}
