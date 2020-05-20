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
        public string Get()
        {
            // Anrop till Test Repo
            return "test";
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
