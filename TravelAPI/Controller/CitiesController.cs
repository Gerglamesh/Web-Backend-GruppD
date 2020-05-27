using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private LinkGenerator _linkGenerator;

        public CitiesController(ICityRepo cityRepo, IMapper mapper, LinkGenerator linkGenerator)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        //GET: api/v1.0/cities/                                 Get all cities
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
                    var cityLinks = CreateLinksForCity(mappedCities[index].CityId, includeCountry, minPopulation, maxPopulation);
                    
                    mappedCities[index].Add(cityLinks);
                }

                return Ok(mappedCities);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        private IEnumerable<Link> CreateLinksForCity(
            int cityId, 
            bool includeCountry = false, 
            int minPopulation = 0, 
            int maxPopulation = 0)
        {
            var links = new List<Link>
            {

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCityById), values: new { cityId, includeCountry}),
                "self",
                "GET"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteCityByID), values: new { cityId }),
                "update_city",
                "DELETE"),

                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(ChangeCityByID), values: new { cityId }),
                "delete_city",
                "PUT"),
            };

            return links;
        }

        private LinkCollectionWrapper<CityDto> CreateLinksForCities(LinkCollectionWrapper<CityDto> ownersWrapper)
        {
            ownersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCities), values: new { }),
                    "self",
                    "GET"));

            return ownersWrapper;
        }

        //GET: api/v1.0/cities/1                                 Get cities by id
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCityById(int id, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.GetCityById(id);

                if (result == null)
                {
                    return NotFound($"Couldn't find any cities with ID: {id}");
                }

                var mappedResult = _mapper.Map<CityDto>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET: api/v1.0/cities/barbados                                 Get cities by name
        [HttpGet("{name}")]
        public async Task<ActionResult<CityDto>> GetCityByName(string name, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.GetCityByName(name, includeCountries);

                if (result == null)
                {
                    return NotFound($"Couldn't find any cities with name: {name}");
                }

                var mappedResult = _mapper.Map<CityDto>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET: api/v1.0/cities/barb                                  Search cities containing
        [HttpGet("search={keyword}")]
        public async Task<ActionResult<CityDto>> SearchCityByName(string keyword, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.SearchCityByKeyword(keyword, includeCountries);

                if (result == null)
                {
                    return NotFound($"Couldn't find any cities containing '{keyword}'");
                }

                var mappedResult = _mapper.Map<CityDto>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //PUT: api/v1.0/city                                     POST City
        [HttpPost]
        public async Task<ActionResult<CityDto>> PostCity(CityDto cityDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<CityModel>(cityDto);
                _cityRepo.Add(mappedEntity);
                if (await _cityRepo.Save())
                {
                    return Created($"/api/v1.0/city/{mappedEntity.CityId}", _mapper.Map<CityDto>(mappedEntity));
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //PUT: api/v1.0/flights/1                                 PUT City
        [HttpPut("{id}")]
        public async Task<ActionResult<CityDto>> ChangeCityByID(int id, [FromBody]CityDto cityDto)
        {
            try
            {
                var oldCity = await _cityRepo.GetCityById(id);

                if (oldCity == null)
                {
                    return NotFound($"Couldn't find any city with ID: {id}");
                }

                var newFlight = _mapper.Map(cityDto, oldCity);
                _cityRepo.Update(newFlight);

                if (await _cityRepo.Save())
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

        //Delete: api/v1.0/cities/1                                Delete City
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCityByID(int id)
        {
            try
            {
                var oldCity = await _cityRepo.GetCityById(id);

                if (oldCity == null)
                {
                    return NotFound($"Couldn't find any city with id: {id}");
                }

                _cityRepo.Delete(oldCity);

                if (await _cityRepo.Save())
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
    }
}
