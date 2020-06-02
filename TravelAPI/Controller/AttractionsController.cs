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

        /// <summary>
        /// Show all attractions.
        /// </summary>
        /// /// <remarks>
        /// 1.Include Cities to see all attractions and where the attraction is located.<br/>
        /// 2.Include isChildFriendly to see all the attractions that is ChildFriendly.<br/>
        /// 3.If you put a number in minRating you will get attractions with the minimum rating.<br/>
        /// 4.If you put a number in maxRating you will get attractions with the maxumim rating.<br/>
        /// 5.If you put a number in both minRating and maxRating you will get attractions with the rating between the two numbers.<br/>
        /// </remarks>
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


        /// <summary>
        /// Show one attraction by its ID.
        /// </summary>
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

        /// <summary>
        /// Show attraction by its name.
        /// </summary>
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


        /// <summary>
        /// Change the conten of a attraction by ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
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


        /// <summary>
        /// Add a new attraction to database.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
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


        /// <summary>
        /// Delete attraction by ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
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
