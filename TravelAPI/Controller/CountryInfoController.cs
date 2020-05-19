using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controller
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CountryInfoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            // Anrop till Test Repo
            return "test";
        }
    }
}
