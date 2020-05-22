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
        {}

        public async Task<ICollection<AttractionModel>> GetAttractions(
            bool includeCities = false,
            bool isChildFriendly = false)
        {
            _logger.LogInformation("Getting Attractions");

            IQueryable<AttractionModel> query = _travelAPIContext.Attractions;

            if (includeCities)
            {
                query = query.Include(a => a.City);
            }
            query.Select(a => a.IsChildFriendly == isChildFriendly);
           
            //if (isChildFriendly)
            //{
            //    query = query.Select(a => new AttractionModel
            //    {
            //        AttractionId = a.AttractionId,
            //        Name = a.Name,
            //        Location = a.Location,
            //        Information = a.Information,
            //        Rating = a.Rating,
            //        IsChildFriendly = a.IsChildFriendly
            //    });
            //        List<AttractionModel> tempList = new List<AttractionModel>();
            //        foreach (var q in query)
            //        {
            //            if (q.IsChildFriendly == isChildFriendly)
            //            {
            //                tempList.Add(q);
            //            }
            //        }
            //        query = tempList.AsQueryable<AttractionModel>();
            //    }
            //else
            //{
            //    query = query.Select(a => new AttractionModel
            //    {
            //        AttractionId = a.AttractionId,
            //        Name = a.Name,
            //        Location = a.Location,
            //        Information = a.Information,
            //        Rating = a.Rating,
            //        IsChildFriendly = a.IsChildFriendly
            //    });
            //}


                query = query.OrderBy(a => a.Name);
            return await query.ToArrayAsync();
        }
        
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
