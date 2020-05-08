using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryRepo : ICountryRepo
    {
        private readonly TravelAPIContext _travelAPIContext;
        public CountryRepo(TravelAPIContext Context)
        {
            _travelAPIContext = Context;
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
