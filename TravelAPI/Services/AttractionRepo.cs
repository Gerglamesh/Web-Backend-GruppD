using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;


namespace TravelAPI.Services
{
    public class AttractionRepo : Repository, IAttractionRepo
    {
        private readonly TravelAPIContext _travelApiContext;

        public AttractionRepo(TravelAPIContext travelAPIContext, ILogger<AttractionRepo> logger) : base(travelAPIContext, logger)
        {
            _travelApiContext = travelAPIContext;
        }

        public async Task<ICollection<AttractionModel>> GetAttractions(bool includeCities = false)
        {
            _logger.LogInformation("Getting Attractions");

            IQueryable<AttractionModel> query = _travelAPIContext.Attractions;

            if (includeCities)
            {
                query.Include(a => a.City);
            }

            query = query.OrderBy(a => a.Name);
            return await query.ToArrayAsync();
        }

        public async Task<AttractionModel> GetAttraction(string name)
        {
            var query = _travelApiContext.Attractions
                .Where(q => q.Name == name);

            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<ICollection<AttractionModel>>GetIschildfriendly(bool isChildFriendly)
        {
            IQueryable<AttractionModel> query = _travelAPIContext.Attractions
                .Where(a => a.IsChildFriendly == isChildFriendly);

            return await query.ToArrayAsync();
        }

        public async Task<ICollection<AttractionModel>>GetRating(int rating)
        {
            var query = _travelApiContext.Attractions
                .Where(q => q.Rating == rating);

            return await query.ToListAsync();
        }
    }
}
