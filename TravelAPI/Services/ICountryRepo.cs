using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICountryRepo : IRepository
    {
        Task<CountryModel[]> GetCountries(
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool isRightHandTraffic = false,
            bool isLeftHandTraffic = false,
            string language = ""
            );

        Task<CountryModel> GetCountryByName(
            string name,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool isRightHandTraffic = false,
            bool isLeftHandTraffic = false
            );

        Task<CountryModel> GetCountryById(
            int id,
            bool includeCities = false,
            bool includeTravelRestrictions = false,
            bool isRightHandTraffic = false,
            bool isLeftHandTraffic = false
            );
    }
}
