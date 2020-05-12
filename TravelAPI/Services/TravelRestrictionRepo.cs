using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class TravelRestrictionRepo : ITravelRestrictionRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public TravelRestrictionRepo(TravelAPIContext Context, ILogger<TravelRestrictionRepo> logger)
        {
            _travelApiContext = Context;
        }
        public async Task<ICollection<TravelRestrictionModel>> GetTravelRestrictions()
        {
            return await _travelApiContext.Set<TravelRestrictionModel>().ToListAsync();
        }
    }
}
