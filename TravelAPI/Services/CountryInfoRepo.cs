using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryInfoRepo : Repository, ICountryInfoRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public CountryInfoRepo(TravelAPIContext Context)
        {
            _travelApiContext = Context;
        }

        public async Task<ICollection<CountryInfoModel>> GetCountryInfos()
        {
            return await _travelApiContext.Set<CountryInfoModel>().ToListAsync();
        }
    }
}
