using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICountryRepo : IRepository
    {
        Task<CountryModel[]> GetCountries(
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5
            );

        Task<CountryModel> GetCountryByName(
            string name,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5
            );

        Task<CountryModel> GetCountryById(
            int id,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5
            );

        Task<CountryModel[]> GetCountriesByRightHandTraffic(
            bool rightHandTraffic,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5
            );

        Task<CountryModel[]> GetCountriesByLanguage(
            string language,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool includeAttractions = false,
            int attractionsMinRating = 0,
            int attractionsMaxRating = 5
            );
    }
}
