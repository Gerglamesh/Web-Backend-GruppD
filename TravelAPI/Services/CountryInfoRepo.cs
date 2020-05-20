using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task<ICollection<CountryInfoModel>> GetCountryInfos()
        {
            return await _travelApiContext.Set<CountryInfoModel>().ToListAsync();
        }
    }
}
