using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAPI.Services;
using AutoMapper;
using TravelAPI.DTO;
using TravelAPI.Models;

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
                var results = await _countryRepo.GetCountries
                (
                    includeCities,
                    includeTravelRestrictions,
                    isRightHandTraffic,
                    isLeftHandTraffic,
                    language
                );

                var mappedResult = _mapper.Map<CountryDto[]>(results);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("search={name}")]
        public async Task<ActionResult<CountryDto>> GetCountryByName(
            string name = "",
            [FromQuery]bool includeCities = false,
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool isRightHandTraffic = false,
            [FromQuery]bool isLeftHandTraffic = false)
        {
            try
            {
                var result = await _countryRepo.GetCountryByName
                (
                    name,
                    includeCities,
                    includeTravelRestrictions,
                    isRightHandTraffic,
                    isLeftHandTraffic
                );

                var mappedResult = _mapper.Map<CountryDto>(result);
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
            [FromQuery]bool includeTravelRestrictions = false,
            [FromQuery]bool isRightHandTraffic = false,
            [FromQuery]bool isLeftHandTraffic = false)
        {
            try
            {
                var result = await _countryRepo.GetCountryById
                (
                    id,
                    includeCities,
                    includeTravelRestrictions,
                    isRightHandTraffic,
                    isLeftHandTraffic
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
    }
}
