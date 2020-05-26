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

        private IQueryable<CityModel> Include(
            IQueryable<CityModel> query,
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0)
        {

            if (includeCoutry)
            {
                query.Include(c => c.Country);
            }

            if (minPopulation > 0 && maxPopulation > 0)
            {
                query.Where(p => p.Population >= minPopulation && p.Population <= maxPopulation)
                    .OrderBy(c => c.Population);
            }
            else if (minPopulation > 0)
            {
                query.Where(p => p.Population >= minPopulation)
                    .OrderBy(c => c.Population);
            }
            else if (maxPopulation > 0)
            {
                query.Where(p => p.Population <= maxPopulation)
                    .OrderBy(c => c.Population);
            }
                return query;
        }

        public async Task<ICollection<CityModel>> GetCities(
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0)
        {
            _logger.LogInformation("Getting Cities.");
            IQueryable<CityModel> query = _travelAPIContext.Cities;
  
            return await Include(query, includeCoutry, minPopulation, maxPopulation)
                .OrderBy(c => c.CityId)
                .ToArrayAsync();
        }

        public async Task<CityModel> GetCityByName(string name, bool includeCountries = false)
        {
            _logger.LogInformation($"Getting City named '{name}')");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(n => n.Name == name);

            return await Include(query, includeCountries)
                .OrderBy(c => c.Name)
                .SingleOrDefaultAsync();
        }

        public async Task<CityModel> GetCityById(int cityId, bool includeCountries = false)
        {
            _logger.LogInformation($"Getting City by ID: {cityId}");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(i => i.CityId == cityId);

            return await Include(query, includeCountries)
                .OrderBy(c => c.CityId)
                .SingleOrDefaultAsync();
        }
    }
}
