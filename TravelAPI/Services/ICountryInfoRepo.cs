using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICountryInfoRepo : IRepository
    {
        Task<CountryInfoModel[]> GetCountryInfo();
        Task<CountryInfoModel> GetCountryInfoByID(int id);
    }
}
