using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    interface ICountryRepo
    {
        Task<ICollection<CountryModel>> GetCountries();
        Task<CountryModel> GetCountry(string name);
        Task<CountryModel> GetCountry(int id);
        Task<ICollection<CountryModel>> GetRightHandTraffic(bool rightHandTraffic);
        Task<ICollection<CountryModel>> GetCountriesByLanguage(string language);
        Task<CountryModel[]> GetCountrys(bool includeCities);
    }
}
