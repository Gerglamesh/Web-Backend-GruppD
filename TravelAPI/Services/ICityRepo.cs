using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICityRepo : IRepository
    {
        Task<ICollection<CityModel>> GetCities(
            bool includeAttractions = false,
            bool IncludeCoutries = false);

        Task<CityModel> GetCityByName(
            string Name,
            bool IncludeCountries = false,
            bool IncludeAttractions = false);

        Task<CityModel> GetCityById(
           int CityId,
           bool IncludeCountries = false,
           bool IncludeAttractions = false);
    }
}
