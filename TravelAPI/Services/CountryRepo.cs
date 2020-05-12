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
        public CountryRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base (travelAPIContext, logger)
        {
        }

        public async Task<ICollection<CountryModel>> GetCountries(
            bool includeCities = false,
            bool IncludeTravelRestrictions = false,
            bool IncludeAttractions = false,
            int AttractionsMinRating = 0,
            int AttraxtionsMaxRating = 5)
        {
            _logger.LogInformation("Getting Country's");
            IQueryable<CountryModel> query = _travelAPIContext.Countries
                .Include(i => i.CountryInfo);
            if(includeCities)
            {
                query = query.Include(c => c.Cities);
            }
            if (IncludeTravelRestrictions)
            {
                query = query.Include(c => c.);
            }
            query = query.OrderBy(e => e.Name);
            return await query.ToArrayAsync();
        }

        public async Task<CountryModel> GetCountry(string name)
        {
            var query = _travelAPIContext.Countries
                .Where(c => c.Name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel> GetCountry(int id)
        {
            var query = _travelAPIContext.Countries
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
