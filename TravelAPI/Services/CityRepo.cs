using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;
namespace TravelAPI.Services
{
    public class CityRepo : ICityRepo
    {
        private readonly TravelAPIContext _travelApiContext;
        public CityRepo(TravelAPIContext Context)
        {
            _travelApiContext = Context;
        }

        public async Task<CityModel> GetCity(string Name)
        {
            var query = _travelApiContext.CityModel
            .Where(s => s.Name == Name);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ICollection<CityModel>> GetCities()
        {
            return await _travelApiContext.Set<CityModel>().ToListAsync();
        }
    }
}
