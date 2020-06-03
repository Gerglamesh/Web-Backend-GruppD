using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class TravelRestrictionsController : ControllerBase
    {
        private readonly ITravelRestrictionRepo _travelRestrictionRepo;
        private readonly IMapper _mapper;

        public TravelRestrictionsController(ITravelRestrictionRepo travelRestrictionRepo, IMapper mapper)
        {
            _travelRestrictionRepo = travelRestrictionRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Show all Travel Restrictions.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<TravelRestrictionModel[]>> GetTravelRestrictions()
        {
            try
            {
                var results = await _travelRestrictionRepo.GetTravelRestrictions();
                return Ok(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            
        }

        /// <summary>
        /// Add a new Travel Restriction.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TravelRestrictionDto>> PostTravelRestriction([FromBody] TravelRestrictionDto travelRestrictionDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<TravelRestrictionModel>(travelRestrictionDto);
                _travelRestrictionRepo.Add(mappedEntity);

                if (await _travelRestrictionRepo.Save()) return Created($"/api/v1.0/travelrestriction/{mappedEntity.TravelRestrictionId}", _mapper.Map<TravelRestrictionModel>(mappedEntity));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Change the content of a Travel Restriction, selected with ID.
        /// </summary>
        /// <remarks>
        /// You need to get the authorization token to make this request.
        /// </remarks>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<TravelRestrictionDto>> ChangeTravelRestrictionByID(int id, [FromBody] TravelRestrictionDto travelRestrictionDto)
        {
            try
            {
                var oldTravelRestriction = await _travelRestrictionRepo.GetTravelRestrictionByID(id);

                if (oldTravelRestriction == null) return NotFound($"Couldn't find any travel restriction with ID: {id}");

                var newTravelRestriction = _mapper.Map(travelRestrictionDto, oldTravelRestriction);
                _travelRestrictionRepo.Update(newTravelRestriction);

                if (await _travelRestrictionRepo.Save()) return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }
    }
}
