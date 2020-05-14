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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;

        public CountryController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CountryModel[]>> GetCountries(
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool includeAttractions = false,
            [FromQuery]int attractionsMinRating = 0,
            [FromQuery]int attractionsMaxRating = 5)
        {
            try
            {
                var results = await _countryRepo.GetCountries(
                    includeCities,
                    includeTravelRestrictions,
                    includeAttractions,
                    attractionsMinRating,
                    attractionsMaxRating);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CountryModel>> GetCountry(
            string name,
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool includeAttractions = false,
            [FromQuery]int attractionsMinRating = 0,
            [FromQuery]int attractionsMaxRating = 5)
        {
            try
            {
                var results = await _countryRepo.GetCountry(
                    name,
                    includeCities,
                    includeTravelRestrictions,
                    includeAttractions,
                    attractionsMinRating,
                    attractionsMaxRating);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetCountry(
            int id,
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool includeAttractions = false,
            [FromQuery]int attractionsMinRating = 0,
            [FromQuery]int AttractionsMaxRating = 5)
        {
            try
            {
                var results = await _countryRepo.GetCountry(
                    id,
                    includeCities,
                    includeTravelRestrictions,
                    includeAttractions,
                    attractionsMinRating,
                    AttractionsMaxRating);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }
    }
}
