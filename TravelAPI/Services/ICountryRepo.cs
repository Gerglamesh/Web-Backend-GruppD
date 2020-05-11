using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICountryRepo : IRepository
    {
        Task<ICollection<CountryModel>> GetCountries();
        Task<CountryModel> GetCountry(string name);
        Task<CountryModel> GetCountry(int id);
        Task<ICollection<CountryModel>> GetRightHandTraffic(bool rightHandTraffic);
        Task<ICollection<CountryModel>> GetCountriesByLanguage(string language);
        Task<CountryModel[]> GetCountries(bool includeCities = false);
    }
}
