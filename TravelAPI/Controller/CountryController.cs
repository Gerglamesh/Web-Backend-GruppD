﻿using Microsoft.AspNetCore.Http;
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
            [FromQuery]bool IncludeCities = false, 
            [FromQuery]bool IncludeTravelRestrictions = false,
            [FromQuery]bool IncludeAttractions = false,
            [FromQuery]int AttractionsMinRating = 0,
            [FromQuery]int AttractionsMaxRating = 5)
        {
            try
            {
                var results = await _countryRepo.GetCountries(
                    IncludeCities, 
                    IncludeTravelRestrictions,
                    IncludeAttractions,
                    AttractionsMinRating,
                    AttractionsMaxRating);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<CountryModel[]>> GetCountry(
            [FromQuery]bool IncludeCities = false,
            [FromQuery]bool IncludeTravelRestrictions = false,
            [FromQuery]bool IncludeAttractions = false,
            [FromQuery]int AttractionsMinRating = 0,
            [FromQuery]int AttractionsMaxRating = 5)
        {
            try
            {
                var results = await _countryRepo.GetCountries(
                    IncludeCities,
                    IncludeTravelRestrictions,
                    IncludeAttractions,
                    AttractionsMinRating,
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
