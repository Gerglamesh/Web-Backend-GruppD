using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Services;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {  
       private readonly IAttractionRepo repository;

        public AttractionController (IAttractionRepo repository)
        {
            this.repository = repository;
        }
    
        
        [HttpGet]
     
        public string Get()
        {
            // Anrop till Test Repo
            return "hej irke";
        }
        
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AttractionController>>> Get()
        //{
        //    return await repository.GetAttraction();
        //}

    }
}
