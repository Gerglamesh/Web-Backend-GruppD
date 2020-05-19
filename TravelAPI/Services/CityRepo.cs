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

        public async Task<ICollection<CityModel>> GetCities(
            bool includeAttractions = false,
            bool includeCountries = false)
        {
            _logger.LogInformation("Getting Cities");
            IQueryable<CityModel> query = _travelAPIContext.Cities
                .Include(a => a.Attractions);
            if (includeAttractions)
            {
                query.Include(a => a.Attractions);
            }
            if (includeCountries)
            {
                query.Include(c => c.Country);
            }
            return await query.ToArrayAsync();
        }

        public async Task<CityModel> GetCityByName(
            string name,
            bool includeCoutries = false,
            bool includeAttractions = false)
        {
            _logger.LogInformation($"Getting City named '{name}')");

            IQueryable<CityModel> query = _travelApiContext.Cities.Where(n => n.Name == name);
            if (includeCoutries)
            {
                query = query.Include(c => c.Country);
            }
            if (includeAttractions)
            {
                query = query.Include(a => a.Attractions);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CityModel> GetCityById(
            int cityId,
            bool includeCoutries = false,
            bool includeAttractions = false)
        {
            _logger.LogInformation("Getting City by Id");

            IQueryable<CityModel> query = _travelApiContext.Cities.Where(i => i.CityId == cityId);
            if (includeCoutries)
            {
                query = query.Include(c => c.Country);
            }
            if (includeAttractions)
            {
                query = query.Include(a => a.Attractions);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
