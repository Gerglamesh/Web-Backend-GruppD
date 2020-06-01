using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<TravelRestrictionModel> GetTravelRestrictionByID(int id)
        {
            var query = _travelAPIContext.TravelRestrictions
                .Where(q => q.TravelRestrictionId == id);
            return await query.SingleOrDefaultAsync();
        }
    }
}
