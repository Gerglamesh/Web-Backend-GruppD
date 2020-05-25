using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        }

        private IQueryable<CityModel> Include(bool includeAttractions, bool includeCountries, IQueryable<CityModel> query)
        {
            if (includeAttractions)
            {
                query.Include(a => a.Attractions);
            }
            if (includeCountries)
            {
                query.Include(c => c.Country);
            }
            return query;
        }

        public async Task<ICollection<CityModel>> GetCities(
            bool includeAttractions = false,
            bool includeCountries = false)
        {
            _logger.LogInformation("Getting Cities.");
            IQueryable<CityModel> query = _travelAPIContext.Cities;
  
            return await Include(includeAttractions, includeCountries, query)
                .ToArrayAsync();
        }


        public async Task<CityModel> GetCityByName(
            string name,
            bool includeCountries = false,
            bool includeAttractions = false)
        {
            _logger.LogInformation($"Getting City named '{name}')");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(n => n.Name == name);

            return await Include(includeAttractions, includeCountries, query)
                .SingleOrDefaultAsync();
        }

        public async Task<CityModel> GetCityById(
            int cityId,
            bool includeCountries = false,
            bool includeAttractions = false)
        {
            _logger.LogInformation($"Getting City by ID: {cityId}");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(i => i.CityId == cityId);

            return await Include(includeAttractions, includeCountries, query)
                .SingleOrDefaultAsync();
        }
    }
}
