using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections;
using System.Threading.Tasks;
using TravelAPI.DTO;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/Country/Info")]
    [ApiController]
    public class CountryInfoController : ControllerBase
    {
        private readonly ICountryInfoRepo _countryInfoRepo;
        private readonly IMapper _mapper;

        public CountryInfoController(ICountryInfoRepo countryInfoRepo, IMapper mapper)
        {
            _countryInfoRepo = countryInfoRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CountryInfoDto[]>> GetCountryInfo()
        {
            try
            {
                var results = await _countryInfoRepo.GetCountryInfo();
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CountryInfoDto>> GetCountryInfoByID(int id)
        {
            try
            {
                var results = await _countryInfoRepo.GetCountryInfoByID(id);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CountryInfoDto>> PostCountry(CountryInfoDto countryInfoDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<CountryInfoModel>(countryInfoDto);
                _countryInfoRepo.Add(mappedEntity);

                if (await _countryInfoRepo.Save())
                {
                    return Created($"/api/v1.0/countryinfo/{mappedEntity.CountryInfoId}", _mapper.Map<CountryModel>(mappedEntity));
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
