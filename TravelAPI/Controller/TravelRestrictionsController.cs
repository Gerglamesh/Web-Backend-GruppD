using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TravelRestrictionsController : ControllerBase
    {
        private readonly ITravelRestrictionRepo _travelRestrictionRepo;

        public TravelRestrictionsController(ITravelRestrictionRepo travelRestrictionRepo)
        {
            _travelRestrictionRepo = travelRestrictionRepo;
        }
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
    }
}
