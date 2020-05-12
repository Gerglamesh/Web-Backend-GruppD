using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICountryRepo : IRepository
    {
        Task<ICollection<CountryModel>> GetCountries(
            bool IncludeCities = false,
            bool IncludeTravelRestrictions = false,
            bool IncludeAttractions = false,
            int AttractionsMinRating = 0,
            int AttractionsMaxRating = 5
            );

        Task<CountryModel> GetCountry(
            string name,
            bool IncludeCities = false,
            bool IncludeTravelRestrictions = false,
            bool IncludeAttractions = false,
            int AttractionsMinRating = 0,
            int AttractionsMaxRating = 5
            );

        Task<CountryModel> GetCountry(
            int id,
            bool IncludeCities = false,
            bool IncludeTravelRestrictions = false,
            bool IncludeAttractions = false,
            int AttractionsMinRating = 0,
            int AttractionsMaxRating = 5
            );

        Task<ICollection<CountryModel>> GetRightHandTraffic(bool rightHandTraffic);

        Task<ICollection<CountryModel>> GetCountriesByLanguage(string language);
    }
}
