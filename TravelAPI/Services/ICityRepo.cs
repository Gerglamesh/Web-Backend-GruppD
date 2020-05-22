using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICityRepo : IRepository
    {
        Task<ICollection<CityModel>> GetCities(
            bool includeAttractions = false,
            bool includeCoutries = false);

        Task<CityModel> GetCityByName(
            string name,
            bool includeCountries = false,
            bool includeAttractions = false);

        Task<CityModel> GetCityById(
           int cityId,
           bool includeCountries = false,
           bool includeAttractions = false);
    }
}
