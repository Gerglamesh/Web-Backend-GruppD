using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;


namespace TravelAPI.Services
{
    public class AttractionRepo : Repository, IAttractionRepo
    {
        public AttractionRepo(TravelAPIContext travelAPIContext, ILogger<AttractionRepo> logger) : base(travelAPIContext, logger)
        { }

        public async Task<AttractionModel[]> GetAttractions(
            bool includeCities = false,
            bool isChildFriendly = false)
        {
            _logger.LogInformation("Get all Attractions");
            IQueryable<AttractionModel> query = _travelAPIContext.Attractions;

            if (includeCities) query = query.Include(a => a.City);
            if (isChildFriendly) query = query.Where(a => a.IsChildFriendly == true);

            query = query.OrderBy(a => a.AttractionId);
            return await query.ToArrayAsync();
        }

        public async Task<AttractionModel> GetAttractionByID(int id)
        {
            var query = _travelAPIContext.Attractions
                .Where(q => q.AttractionId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AttractionModel> GetAttractionByName(string name)
        {
            var query = _travelAPIContext.Attractions
                .Where(q => q.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<AttractionModel>> GetIschildfriendly(bool isChildFriendly = false)
        {
            IQueryable<AttractionModel> query = _travelAPIContext.Attractions
                .Where(a => a.IsChildFriendly == isChildFriendly);

            return await query.ToArrayAsync();
        }

        public async Task<ICollection<AttractionModel>> GetAttractionByRating(int rating)
        {
            var query = _travelAPIContext.Attractions
                .Where(q => q.Rating == rating);

            return await query.ToListAsync();
        }
    }
}
