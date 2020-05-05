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
        private readonly TravelAPIContext dbcontext;
        public CityRepo(TravelAPIContext Context)
        {
            dbcontext = Context;
        }

        public async Task<CityModel> GetCityModel()
        {
            var query = dbcontext.CityModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
