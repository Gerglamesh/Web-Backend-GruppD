using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryRepo : Repository, ICountryRepo
    {
        private readonly TravelAPIContext _travelAPIContext;
        public CountryRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base (travelAPIContext, logger)
        {

        }

        public async Task<CountryModel[]> GetCountrys(bool includeCities = false)
        {
            _logger.LogInformation("Getting Country's");
            IQueryable<CountryModel> query = _travelAPIContext.CountryModel
                .Include(i => i.CountryInfo);
            if(includeCities)
            {
                query = query.Include(c => c.Cities);
            }
            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }

        public async Task<ICollection<CountryModel>> GetCountries()
        {
            return await _travelAPIContext.Set<CountryModel>().ToListAsync();  
        }

        public async Task<CountryModel> GetCountry(string name)
        {
            var query = _travelAPIContext.CountryModel
                .Where(c => c.Name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel> GetCountry(int id)
        {
            var query = _travelAPIContext.CountryModel
                .Where(c => c.CountryId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<CountryModel>> GetRightHandTraffic(bool isRightHandTraffic)
        {
            return await _travelAPIContext.Set<CountryModel>().Where(s => s.CountryInfo.RightHandTraffic == true).ToListAsync();

        }
        public async Task<ICollection<CountryModel>> GetCountriesByLanguage(string language)
        {
            return await _travelAPIContext
                .Set<CountryModel>()
                .Where(c => c.CountryInfo.Language.Contains(language)).ToListAsync();
        }
    }
}
