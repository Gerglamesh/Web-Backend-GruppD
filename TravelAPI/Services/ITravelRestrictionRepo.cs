using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ITravelRestrictionRepo : IRepository
    {
        Task<ICollection<TravelRestrictionModel>> GetTravelRestrictions();
        Task<TravelRestrictionModel> GetTravelRestrictionByID(int id);
    }
}
