using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.DTO;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {  
       private readonly IAttractionRepo _attractionRepo;
        private readonly IMapper _mapper;

        public AttractionController (IAttractionRepo attractionRepo, IMapper mapper)
        {
            _attractionRepo = attractionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<AttractionDto[]>>> GetAttractions([FromQuery]bool includeCities = false)            
        {
            try
            {
                var results = await _attractionRepo.GetAttractions(includeCities);
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AttractionDto>> PostEvent(AttractionDto attractionDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<AttractionModel>(attractionDto);
                _attractionRepo.Add(mappedEntity);
                if (await _attractionRepo.Save())
                {
                    return Created($"/api/v1.0/events/{mappedEntity.AttractionId}", _mapper.Map<AttractionDto>(mappedEntity));
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
