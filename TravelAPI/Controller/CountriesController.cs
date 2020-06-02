﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAPI.Services;
using AutoMapper;
using TravelAPI.DTO;
using TravelAPI.Models;
using System.Linq;
using TravelAPI.Hateoas;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepo countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

    [HttpGet]
    public async Task<ActionResult<CountryDto[]>> GetCountries(
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool isRightHandTraffic = false,
            [FromQuery]bool isLeftHandTraffic = false,
            [FromQuery]string language = "")
    {
        try
        {
            var countries = await _countryRepo.GetCountries(includeCities, includeTravelRestrictions, isRightHandTraffic, isLeftHandTraffic, language);
            var mappedCountries = _mapper.Map<CountryDto[]>(countries);

            for (var i = 0; i < mappedCountries.Count(); i++)
            {
                var countryLinks = CreateLinksForCountries(mappedCountries[i].CountryId);
                var attractionLinks = CreateLinksForCountryAttractions(countries[i]);

                    mappedCountries[i].Add(countryLinks, attractionLinks);
            }

            return Ok(mappedCountries);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
        }
    }

    [HttpGet("search={name}")]
        public async Task<ActionResult<CountryDto[]>> GetCountryByName(
            string name = "",
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false)
        {
            try
            {
                var results = await _countryRepo.GetCountryByName
                (
                    name,
                    includeCities,
                    includeTravelRestrictions
                );

                var mappedResult = _mapper.Map<CountryDto[]>(results);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountryById(
            int id,
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false)
        {
            try
            {
                var result = await _countryRepo.GetCountryById
                (
                    id,
                    includeCities,
                    includeTravelRestrictions
                );

                if (result == null)
                {
                    return NotFound($"Couldn't find any cities with ID: {id}");
                }

                var mappedResult = _mapper.Map<CountryDto>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> PostCountry(CountryDto countryDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<CountryModel>(countryDto);
                _countryRepo.Add(mappedEntity);

                if (await _countryRepo.Save())
                {
                    return Created($"/api/v1.0/countries/{mappedEntity.CountryId}", _mapper.Map<CountryModel>(mappedEntity));
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CountryDto>> ChangeCountryByID(int id, [FromBody]CountryDto countryDto)
        {
            try
            {
                var oldCountry = await _countryRepo.GetCountryById(id);

                if (oldCountry == null)
                {
                    return NotFound($"Couldn't find any country with id: {id}");
                }

                var newCountry = _mapper.Map(countryDto, oldCountry);
                _countryRepo.Update(newCountry);

                if (await _countryRepo.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountryByID(int id)
        {
            try
            {
                var oldCountry = await _countryRepo.GetCountryById(id);

                if (oldCountry == null)
                {
                    return NotFound($"Couldn't find any country with id: {id}");
                }

                _countryRepo.Delete(oldCountry);

                if (await _countryRepo.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        private IEnumerable<Link> CreateLinksForCountries(int countryId)
        {
            string currentUrl = Request.GetDisplayUrl();
            int count = countryId.ToString().Length;

            var links = new List<Link>
            {
                new Link($"{currentUrl}/{countryId}",
                "self",
                Request.Method),

                new Link(currentUrl,
                "get_countries",
                "GET"),

                new Link(currentUrl,
                "post_countries",
                "POST"),

                new Link($"{currentUrl}/{countryId}",
                "put_countries",
                "PUT"),

                new Link($"{currentUrl}/{countryId}",
                "delete_country",
                "DELETE")
            };
            return links;
        }

        private IEnumerable<Link> CreateLinksForCountryAttractions(CountryModel countrymodel)
        {
            var links = new List<Link>();

            foreach(var city in countrymodel.Cities)
            {
                if(city.Attractions != null)
                {
                    foreach(var attraction in city.Attractions)
                    {
                        links.Add(new Link($"http://localhost:50615/attractions/{attraction.AttractionId}", "self", "GET"));
                    }
                }
            }

            return links;
        }
    }
}
