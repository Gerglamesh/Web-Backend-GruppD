﻿using Microsoft.EntityFrameworkCore;
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
        public AttractionRepo(TravelAPIContext travelAPIContext, ILogger<CountryRepo> logger) : base(travelAPIContext, logger)
        {
            _travelApiContext = travelAPIContext;
        }
        public async Task<AttractionModel> GetAttraction(string name)
        {
            var query = _travelApiContext.Attractions
                .Where(q => q.Name == name);
            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<ICollection<AttractionModel>>GetIschildfriendly(bool IsChildFriendly)
        {
            return await _travelApiContext
              .Set<AttractionModel>()
             .Where(a => a.IsChildFriendly == true).ToListAsync();
        }


        public async Task<ICollection<AttractionModel>>GetRating(int rating)
        {
            var query = _travelApiContext.Attractions
                .Where(q => q.Rating == rating);
            return await query.ToListAsync();
        }
    }
}
