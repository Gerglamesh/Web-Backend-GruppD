using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICityRepo : IRepository
    {
        Task<ICollection<CityModel>> GetCities(
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0);

        Task<CityModel> GetCityByName(
            string name,
            bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0);

        Task<CityModel> GetCityById(
           int cityId,
           bool includeCoutry = false,
            int minPopulation = 0,
            int maxPopulation = 0,
            int minRating = 0,
            int maxRating = 0);
    }
}
