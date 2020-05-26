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

        private IQueryable<AttractionModel> GetAttractionByRating(int minRating, int maxRating, IQueryable<AttractionModel> query)
        {
            if (minRating > 0 && maxRating > 0)
            {
                _logger.LogInformation($"Getting attractions with rating between {minRating} and {maxRating}");
                query = _travelAPIContext.Attractions.Where(x => x.Rating >= minRating && x.Rating <= maxRating)
                    .OrderBy(x => x.Rating);
            }

            else if (minRating > 0)
            {
                _logger.LogInformation($"Getting attractions with rating more than {minRating}");
                query = _travelAPIContext.Attractions
                    .Where(x => x.Rating >= minRating)
                    .OrderBy(r => r.Rating);
            }

            else if (maxRating > 0)
            {
                _logger.LogInformation($"Getting attractions with {maxRating} in rating");
                query = _travelAPIContext.Attractions
                    .Where(x => x.Rating <= maxRating)
                    .OrderBy(r => r.Rating);
            }

            _logger.LogInformation($"Get all attractions with min rating:{minRating} and max rating:{maxRating}");

            return query;
        }

        public async Task<AttractionModel[]> GetAttractions(
            int minRating,
            int maxRating,
            bool includeCities = false,
            bool isChildFriendly = false)
        {
            _logger.LogInformation("Get all Attractions");
            IQueryable<AttractionModel> query = _travelAPIContext.Attractions;

            if (includeCities) query = query.Include(a => a.City);
            if (isChildFriendly) query = query.Where(a => a.IsChildFriendly == true);

            query = query.OrderBy(a => a.CityId);
            query = GetAttractionByRating(minRating, maxRating, query);
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
    }
}
