using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.DTO;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]

    public class CityController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;
        public CityController(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CityModel[]>> GetCities([FromQuery]bool includeAttractions = false)
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

        [HttpPost]
        public async Task<ActionResult<CityDto>> PostEvent(CityDto cityDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<CityModel>(cityDto);
                _cityRepo.Add(mappedEntity);
                if (await _cityRepo.Save())
                {
                    return Created($"/api/v1.0/events/{mappedEntity.CityId}", _mapper.Map<CityDto>(mappedEntity));
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
