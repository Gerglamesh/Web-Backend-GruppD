using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TravelRestrictionsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            // Anrop till Test Repo
            return "hej irke";
        }
    }
}
