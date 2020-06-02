using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelAPI.Services;
using AutoMapper;
using TravelAPI.DTO;
using TravelAPI.Models;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
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

        [Authorize]
        [HttpPut("{attractionid}")]
        public async Task<ActionResult<AttractionDto>> PutAttraction(int attractionid, [FromBody] AttractionDto attractionDto)
        {
            try
            {
                var oldattraction = await _attractionRepo.GetAttractionByID(attractionid);
                if (oldattraction == null)
                {
                    return NotFound($"There is no attraction with id:{attractionid}");
                }
                var newAttraction = _mapper.Map(attractionDto, oldattraction);
                _attractionRepo.Update(newAttraction);
                if (await _attractionRepo.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure:{e.Message}");
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AttractionDto>> PostAttraction(AttractionDto attractionDto)
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

        [Authorize]
        [HttpDelete("{attractionid}")]
        public async Task<ActionResult<AttractionDto>> DeleteAttraction(int attractionid)
        {
            try
            {
                var oldAttraction = await _attractionRepo.GetAttractionByID(attractionid);
                if (oldAttraction == null)
                {
                    return NotFound($"There is no attraction with the id: {attractionid}");
                }

                _attractionRepo.Delete(oldAttraction);

                if (await _attractionRepo.Save())
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure:{e.Message}");
            }
            return BadRequest();
        }
    }
}
