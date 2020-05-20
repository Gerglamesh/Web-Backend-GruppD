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
        public AttractionRepo(TravelAPIContext travelAPIContext, ILogger<AttractionRepo> logger) : base (travelAPIContext, logger)
        {        }
        
        public async Task<AttractionModel> GetAttraction(int id)
        {
            var query = _travelAPIContext.Attractions
                .Where(q => q.AttractionId == id);
            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<AttractionModel> GetAttraction(string name)
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

        public async Task<ICollection<AttractionModel>>GetRating(int rating)
        {
            var query = _travelAPIContext.Attractions
                .Where(q => q.Rating == rating);

            return await query.ToListAsync();
        }
    }
}
