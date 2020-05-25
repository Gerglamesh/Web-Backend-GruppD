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
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0)
        {
            if (includeCoutry)
            {
                query.Include(c => c.Country);
            }

            if (minPopulation > 0 && maxPopulation > 0)
            {
                query.Where(p => p.Population > minPopulation && p.Population < maxPopulation);
            }
            else if (minPopulation > 0)
            {
                query.Where(p => p.Population > minPopulation);
            }
            else if(maxPopulation > 0)
            {
                query.Where(p => p.Population < maxPopulation);
            }

            if (minRating > 0 && maxRating > 0)
            {
            }

            return query;
        }

        public async Task<ICollection<CityModel>> GetCities(
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0)
        {
            _logger.LogInformation("Getting Cities.");
            IQueryable<CityModel> query = _travelAPIContext.Cities;
  
            return await Include(
                query, 
                includeCoutry, 
                minPopulation, 
                maxPopulation, 
                minRating, 
                maxRating)
                .ToArrayAsync();
        }


        public async Task<CityModel> GetCityByName(
            string name,
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0)
        {
            _logger.LogInformation($"Getting City named '{name}')");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(n => n.Name == name);

            return await Include(
                query,
                includeCoutry,
                minPopulation,
                maxPopulation,
                minRating,
                maxRating)
                .SingleOrDefaultAsync();
        }

        public async Task<CityModel> GetCityById(
            int cityId,
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0)
        {
            _logger.LogInformation($"Getting City by ID: {cityId}");
            IQueryable<CityModel> query = _travelApiContext.Cities.Where(i => i.CityId == cityId);

            return await Include(
                query,
                includeCoutry,
                minPopulation,
                maxPopulation,
                minRating,
                maxRating)
                .SingleOrDefaultAsync();
        }
    }
}
