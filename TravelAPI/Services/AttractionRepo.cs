using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;


namespace TravelAPI.Services
{
    public class AttractionRepo : IAttractionRepo
    {
        private readonly TravelAPIContext dbcontext;
        public AttractionRepo(TravelAPIContext Context)
        {
            dbcontext = Context;
        }
        public async Task<AttractionModel> GetAttractionModel()
        {
            var query = dbcontext.AttractionModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
