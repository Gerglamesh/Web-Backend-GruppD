using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryRepo
    {
        private readonly TravelAPIContext _travelAPIContext;
        public CountryRepo(TravelAPIContext Context)
        {
            _travelAPIContext = Context;
        }

        public async Task<CountryModel> GetCountryModel()
        {
            var query = _travelAPIContext.CountryModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
