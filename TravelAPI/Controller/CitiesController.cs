using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAPI.DTO;
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

        //GET: api/v1.0/cities/                                 Get all cities
        [HttpGet]
        public async Task<ActionResult<CityModel[]>> GetCities(
            [FromQuery] bool includeCountry = false,
            [FromQuery] int minPopulation = 0,
            [FromQuery] int maxPopulation = 0)
        {
            try
            {
                var results = await _cityRepo.GetCities(includeCountry, minPopulation, maxPopulation);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
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
                var result = await _cityRepo.SearchCityByName(keyword, includeCountries);

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
