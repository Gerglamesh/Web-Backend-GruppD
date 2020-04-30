using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class PrototypeRepo : IPrototypeRepo
    {
        private readonly PrototypeContext dbcontext;

        public async Task<PrototypeModel> GetPrototype()
        {
            var query = dbcontext.PrototypeModel;
            return await query.FirstOrDefaultAsync();
        }
    }
}
