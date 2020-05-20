using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class TravelRestrictionRepo : Repository, ITravelRestrictionRepo
    {
        private readonly TravelAPIContext _travelApiContext;

        public TravelRestrictionRepo(TravelAPIContext Context, ILogger<TravelRestrictionRepo> logger): base(Context, logger)
        {
            _travelApiContext = Context;
        }

        public async Task<ICollection<TravelRestrictionModel>> GetTravelRestrictions()
        {
            _logger.LogInformation("Getting Travel restrictions");
            return await _travelApiContext.Set<TravelRestrictionModel>().ToListAsync();
        }
    }
}
