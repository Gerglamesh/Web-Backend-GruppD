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
            bool IncludeAttractions = false,
            bool IncludeCountries = false)
        {
            _logger.LogInformation("Getting Cities");
            IQueryable<CityModel> query = _travelAPIContext.Cities
                .Include(a => a.Attractions);
            if (IncludeAttractions)
            {
                query.Include(a => a.Attractions);
            }
            if (IncludeCountries)
            {
                query.Include(c => c.Country);
            }
            return await query.ToArrayAsync();
        }

        public async Task<CityModel> GetCityByName(
            string name,
            bool IncludeCoutries = false,
            bool IncludeAttractions = false)
        {
            _logger.LogInformation($"Getting City named '{name}')");

            IQueryable<CityModel> query = _travelApiContext.Cities.Where(n => n.Name == name);
            if (IncludeCoutries)
            {
                query = query.Include(c => c.Country);
            }
            if (IncludeAttractions)
            {
                query = query.Include(a => a.Attractions);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CityModel> GetCityById(
            int CityId,
            bool IncludeCoutries = false,
            bool IncludeAttractions = false)
        {
            _logger.LogInformation("Getting City by Id");

            IQueryable<CityModel> query = _travelApiContext.Cities.Where(i => i.CityId == CityId);
            if (IncludeCoutries)
            {
                query = query.Include(c => c.Country);
            }
            if (IncludeAttractions)
            {
                query = query.Include(a => a.Attractions);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
