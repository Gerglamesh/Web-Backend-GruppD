using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICityRepo : IRepository
    {
        Task<CityModel[]> GetCities(
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0);

        Task<CityModel> GetCityByName(
            string name,
            bool includeCountries = false);

        Task<CityModel> GetCityById(
           int cityId,
           bool includeCountries = false);

        Task<CityModel[]> SearchCityByKeyword(
           string keyword,
           bool includeCountries = false);
    }
}
