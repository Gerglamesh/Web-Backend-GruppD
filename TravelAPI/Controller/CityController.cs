using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;
        public CityController(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }
        [HttpGet]
        public async Task<ActionResult<CityModel[]>> GetCities([FromQuery]bool IncludeAttractions = false)
        {
            try
            {
                var results = await _cityRepo.GetCities(includeAttractions);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");

            }
        }
    }
}
