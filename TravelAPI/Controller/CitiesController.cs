using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Controllers;
using TravelAPI.DTO;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CitiesController : HateoasCitiesControllerBase
    {
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;

        public CitiesController(
            ICityRepo cityRepo, 
            IMapper mapper,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(actionDescriptorCollectionProvider)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        //GET: api/v1.0/cities/                                 Get all cities
        [HttpGet(Name = "GetCities")]
        public async Task<ActionResult<IList<CityDto>>> GetCities(
            [FromQuery] bool includeCountry = false,
            [FromQuery] int minPopulation = 0,
            [FromQuery] int maxPopulation = 0)
        {
            try
            {
                var results = await _cityRepo.GetAllCities();

                IEnumerable<CityDto> mappedResults = _mapper.Map<IList<CityDto>>(results);
                IEnumerable<CityDto> hateoasResults = mappedResults.Select(m => HateoasMainLinks(m));


                return Ok(hateoasResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET: api/v1.0/cities/1                                 Get cities by id
        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<ActionResult<CityDto>> GetCityById(int id, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.GetCityById(id);

                if (result == null) return NotFound($"Couldn't find any cities with ID: {id}");
               
                var mappedResult = _mapper.Map<CityDto>(result);

                return Ok(HateoasMainLinks(mappedResult));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET: api/v1.0/cities/barbados                                 Get cities by name
        [HttpGet("{name}", Name = "GetCityByName")]
        public async Task<ActionResult<CityDto>> GetCityByName(string name, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.GetCityByName(name, includeCountries);

                if (result == null) return NotFound($"Couldn't find any cities with name: {name}");

                var mappedResult = _mapper.Map<CityDto>(result);

                return Ok(HateoasMainLinks(mappedResult));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET: api/v1.0/cities/barb                                  Search cities containing
        [HttpGet("search={keyword}", Name = "SearchCityByKeyword")]
        public async Task<ActionResult<CityDto[]>> SearchCityByKeyword(string keyword, bool includeCountries = false)
        {
            try
            {
                var result = await _cityRepo.SearchCityByKeyword(keyword, includeCountries);

                if (result == null) return NotFound($"Couldn't find any cities containing '{keyword}'");

                var mappedResult = _mapper.Map<CityDto>(result);

                return Ok(HateoasMainLinks(mappedResult));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> PostEvent(CityDto cityDto)
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
    }
}
