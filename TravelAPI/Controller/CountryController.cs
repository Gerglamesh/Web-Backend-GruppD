using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase     
    {
        //Repo prop here
        //private readonly TravelAPIContext context;

        public CountryController()
        {
            //Inject repo
            //this.context = context;
        }

        [HttpGet]
        public string Get()
        {
            // Anrop till Fake Repo
            return "Hi from CountryController";
        }

        [HttpGet]
        public async Task<ActionResult<CountryController[]>> GetCountry()
        {
            var results = await _countryRepo
            return true;
        }
    }
}
