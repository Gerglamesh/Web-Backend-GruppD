using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryInfoRepo : ICountryInfoRepo
    {
        private readonly TravelAPIContext dbcontext;
        public CountryInfoRepo(TravelAPIContext Context)
        {
            dbcontext = Context;
        }

        public async Task<CountryInfoModel> GetCountryInfoModel()
        {
            var query = dbcontext.CountryInfoModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
