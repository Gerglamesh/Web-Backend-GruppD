using Microsoft.EntityFrameworkCore;
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
        public AttractionRepo(TravelAPIContext context)
        {
            _travelApiContext = context;
        }
        public async Task<AttractionModel> GetAttraction(string name)
        {
            var query = _travelApiContext.Attractions
                .Where(q => q.Name == name);
            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<ICollection<AttractionModel>> GetIschildfriendly (bool IsChildFriendly)
        {
            return await _travelApiContext
              .Set<AttractionModel>()
             .Where(a => a.IsChildFriendly == true).ToListAsync();
        }
    }
}
