using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;
namespace TravelAPI.Services
{
    public class CityRepo : Repository, ICityRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public CityRepo(TravelAPIContext travelAPIContext, ILogger<CityRepo> logger) : base(travelAPIContext, logger)
        {
            _travelApiContext = travelAPIContext;
        }

        public async Task<CityModel> GetCity(string Name)
        {
            var query = _travelApiContext.Cities
            .Where(s => s.Name == Name);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ICollection<CityModel>> GetCities(bool includeAttractions = false)
        {
            IQueryable<CityModel> query = _travelAPIContext.Cities;
            if (includeAttractions)
            {
                query.Include(c => c.Attractions);
            }


            return await query.ToArrayAsync();

        }
    }
}
