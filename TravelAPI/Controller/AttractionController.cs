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
        public async Task<ActionResult<AttractionDto[]>> GetAttraction(string name)
        {
            try
            {
                var results = await _attractionRepo.GetAttraction(name);
                var mappedResults = _mapper.Map<AttractionDto[]>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{rating}")]
        public async Task<ActionResult<AttractionDto[]>> GetAttractionByRating(int rating)
        {
            try
            {
                var result = await _attractionRepo.GetRating(rating);
                var mappedResult = _mapper.Map<AttractionDto[]>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{childfriendly}")]
        public async Task<ActionResult<AttractionDto[]>> GetAttractionByChildFriendly(bool isChildFriendly)
        {
            try
            {
                var result = await _attractionRepo.GetIschildfriendly(isChildFriendly);
                var mappedResult = _mapper.Map<AttractionDto[]>(isChildFriendly);
                return Ok(mappedResult);
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
