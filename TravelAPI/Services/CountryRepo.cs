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

        public async Task<CountryModel> GetCity(string name)
        {
            var query = _travelAPIContext.CountryModel
                .Where(c => c.Name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<CountryModel> GetCity(int id)
        {
            var query = _travelAPIContext.CountryModel
                .Where(c => c.CountryId == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
