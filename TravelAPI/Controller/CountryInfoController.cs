using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Show all Country Info.
        /// </summary>
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

        /// <summary>
        /// Show a Country Info by ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CountryInfoDto>> GetCountryInfoByID(int id)
        {
            try
            {
                var results = await _countryInfoRepo.GetCountryInfoByID(id);
                if (results == null)
                {
                    return NotFound($"Couldn't find any Country Information on a Country with ID: {id}");
                }
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        /// <summary>
        /// Add a new Country Info.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
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

        /// <summary>
        /// Change the content of a Country Info, selected with ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CountryInfoDto>> ChangeCountryInfoByID(int id, [FromBody]CountryInfoDto countryInfoDto)
        {
            try
            {
                var oldCountryInfo = await _countryInfoRepo.GetCountryInfoByID(id);

                if (oldCountryInfo == null)
                {
                    return NotFound($"Couldn't find any country with id: {id}");
                }

                var newCountry = _mapper.Map(countryInfoDto, oldCountryInfo);
                _countryInfoRepo.Update(newCountry);

                if (await _countryInfoRepo.Save())
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
