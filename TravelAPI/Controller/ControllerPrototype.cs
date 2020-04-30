using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class PrototypeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            // Anrop till Fake Repo
            return "Hi there";
        }
    }
}
