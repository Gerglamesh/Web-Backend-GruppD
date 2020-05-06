using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;
namespace TravelAPI.Services
{
    public class CityRepo : ICityRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public CityRepo(TravelAPIContext Context)
        {
            _travelApiContext = Context;
        }

        public async Task<CityModel> GetCityModel()
        {
            var query = _travelApiContext.CityModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
