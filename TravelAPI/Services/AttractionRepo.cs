﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;


namespace TravelAPI.Services
{
    public class AttractionRepo : IAttractionRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public AttractionRepo(TravelAPIContext context)
        {
            _travelApiContext = context;
        }
        public async Task<AttractionModel> GetAttraction(string name)
        {
            var query = _travelApiContext.AttractionModel
                .Where(q => q.Name == name);
            return await query.FirstOrDefaultAsync();
        }
    }
}
