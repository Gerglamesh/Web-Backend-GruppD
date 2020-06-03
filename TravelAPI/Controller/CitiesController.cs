using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TravelAPI.DTO;
using TravelAPI.Hateoas;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepo cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Cities.
        /// </summary>
        /// /// <remarks>
        /// Use "?includeCountry" to get the relational data from the country where the city is located.<br/>
        /// Use "minPopulation={int}" to get all cities with a population higher than the number entered.<br/>
        /// Use "maxPopulation={int}" to get all cities with a population lower than the number entered.<br/>
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<CityDto[]>> GetCities(
            [FromQuery] bool includeCountry = false,
            [FromQuery] int minPopulation = 0,
            [FromQuery] int maxPopulation = 0)
        {
            try
            {
                var cities = await _cityRepo.GetCities(includeCountry, minPopulation, maxPopulation);
                var mappedCities = _mapper.Map<CityDto[]>(cities);

                for (var index = 0; index < mappedCities.Count(); index++)
                {
                    var cityLinks = CreateLinksForCities(mappedCities[index].CityId);
                    var attractionLinks = CreateLinksForCityAttractions(cities[index]);

                    mappedCities[index].Add(cityLinks, attractionLinks);
                }

                return Ok(mappedCities);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        /// <summary>
        /// Get one city by ID.
        /// </summary>
        /// /// /// <remarks>
        /// Use "?includeCountry" to get the relational data from the country where the city is located.<br/>
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCityById(int id, [FromQuery] bool includeCountries = false)
        {
            try
            {
                var city = await _cityRepo.GetCityById(id, includeCountries);

                if (city == null) return NotFound($"Couldn't find any cities with ID: {id}");
                
                var mappedCity = _mapper.Map<CityDto>(city);

                var cityLinks = CreateLinksForCity(mappedCity.CityId);
                var attractionLinks = CreateLinksForCityAttractions(city);

                mappedCity.Add(cityLinks, attractionLinks);

                return Ok(mappedCity);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        /// <summary>
        /// Gets a city by name.
        /// </summary>
        /// /// /// <remarks>
        /// Use "?includeCountry" to get the relational data from the country where the city is located.<br/>
        /// </remarks>
        [HttpGet("{name}")]
        public async Task<ActionResult<CityDto>> GetCityByName(string name, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.GetCityByName(name, includeCountries);

                if (result == null) return NotFound($"Couldn't find any cities with name: {name}");
                
                var mappedResult = _mapper.Map<CityDto>(result);
                
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        /// <summary>
        /// Searches the database for cities containing keyword(s).
        /// </summary>
        /// /// /// <remarks>
        /// Use "?includeCountry" to get the relational data from the country where the city is located.<br/>
        /// </remarks>
        [HttpGet("search={keyword}")]
        public async Task<ActionResult<CityDto[]>> SearchCityByName(string keyword, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.SearchCityByKeyword(keyword, includeCountries);

                if (result == null) return NotFound($"Couldn't find any cities containing '{keyword}'");

                var mappedResult = _mapper.Map<CityDto[]>(result);
                
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        /// <summary>
        /// Add a new City to database.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CityDto>> PostEvent([FromBody] CityDto cityDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<CityModel>(cityDto);
                _cityRepo.Add(mappedEntity);

                if (await _cityRepo.Save())
                {
                    return Created($"/api/v1.0/cities/{mappedEntity.CityId}", _mapper.Map<CityDto>(mappedEntity));
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Change the content of a city by ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CityDto>> ChangeCityByID(int id, [FromBody] CityDto cityDto)
        {
            try
            {
                var oldCity = await _cityRepo.GetCityById(id);

                if (oldCity == null) return NotFound($"Couldn't find any city with ID: {id}");

                var newCity = _mapper.Map(cityDto, oldCity);
                _cityRepo.Update(newCity);

                if (await _cityRepo.Save()) return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a city by ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCityByID(int id)
        {
            try
            {
                var oldCity = await _cityRepo.GetCityById(id);

                if (oldCity == null) return NotFound($"Couldn't find any city with id: {id}");

                _cityRepo.Delete(oldCity);

                if (await _cityRepo.Save()) return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        private IEnumerable<Link> CreateLinksForCity(int cityId)
        {
            string currentUrl = Request.GetDisplayUrl();
            int count = cityId.ToString().Length;

            var links = new List<Link>
            {
                new Link(currentUrl,
                "self",
                "GET"),

                new Link(currentUrl.Remove(currentUrl.Length -1, count),
                "get_cities",
                Request.Method),


                new Link(currentUrl,
                "post_cities",
                "POST"),

                 new Link(currentUrl,
                "put_cities",
                "PUT"),

                 new Link(currentUrl,
                "delete_city",
                "DELETE")
            };

            return links;
        }
        private IEnumerable<Link> CreateLinksForCities(int cityId)
        {
            string currentUrl = Request.GetDisplayUrl();
            int count = cityId.ToString().Length;

            var links = new List<Link>
            {
                new Link($"{currentUrl}/{cityId}",
                "self",
                Request.Method),

                new Link(currentUrl,
                "get_cities",
                "GET"),

                new Link(currentUrl,
                "post_cities",
                "POST"),

                 new Link($"{currentUrl}/{cityId}",
                "put_cities",
                "PUT"),

                 new Link($"{currentUrl}/{cityId}",
                "delete_city",
                "DELETE")
            };

            return links;
        }

        private IEnumerable<Link> CreateLinksForCityAttractions(CityModel citymodel)
        {
            var links = new List<Link>();

            if (citymodel.Attractions != null)
            {
                foreach (var attraction in citymodel.Attractions)
                {
                    links.Add(new Link($"http://localhost:50615/attractions/{attraction.AttractionId}", "self", "GET"));
                }
            }

            return links;
        }
    }
}
