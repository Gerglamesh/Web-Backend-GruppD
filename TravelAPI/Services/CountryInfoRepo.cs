using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class CountryInfoRepo : Repository, ICountryInfoRepo
    {
        private readonly TravelAPIContext _travelApiContext;

        public CountryInfoRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base(travelAPIContext, logger)
        {
            _travelApiContext = travelAPIContext;
        }

        public async Task<CountryInfoModel[]> GetCountryInfo()
        {
            IQueryable<CountryInfoModel> query = _travelAPIContext.CountryInfo;

            query = query.OrderBy(a => a.CountryInfoId);

            return await query.ToArrayAsync();
        }

        public async Task<CountryInfoModel> GetCountryInfoByID(int id)
        {
            var query = _travelAPIContext.CountryInfo
                .Where(q => q.CountryInfoId == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
