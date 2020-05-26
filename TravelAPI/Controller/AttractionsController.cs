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
    public class AttractionsController : ControllerBase
    {  
       private readonly IAttractionRepo _attractionRepo;
        private readonly IMapper _mapper;

        public AttractionsController (IAttractionRepo attractionRepo, IMapper mapper)
        {
            _attractionRepo = attractionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AttractionDto[]>> GetAttractions(
            [FromQuery]int minRating,
            [FromQuery]int maxRating,
            [FromQuery]bool includeCities = false,
            [FromQuery]bool isChildFriendly = false)       
        {
            try
            {
                var results = await _attractionRepo.GetAttractions(minRating,maxRating,includeCities, isChildFriendly);
                var mappedResults = _mapper.Map<AttractionDto[]>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AttractionDto>> GetAttractionByID(int id)
        {
            try
            {
                var results = await _attractionRepo.GetAttractionByID(id);
                var mappedResults = _mapper.Map<AttractionDto>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<AttractionDto>> GetAttractionByName(string name)
        {
            try
            {
                var results = await _attractionRepo.GetAttractionByName(name);
                var mappedResults = _mapper.Map<AttractionDto>(results);
                return Ok(mappedResults);
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
                    return Created($"/api/v1.0/attraction/{mappedEntity.AttractionId}", _mapper.Map<AttractionDto>(mappedEntity));
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
