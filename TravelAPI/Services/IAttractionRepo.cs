using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IAttractionRepo : IRepository
    {
        Task<AttractionModel[]> GetAttractions(
            int minRating,
            int maxRating,
            bool includeCities = false,
            bool isChildFriendly = false);
        Task<AttractionModel>GetAttractionByID(int id);
        Task<AttractionModel>GetAttractionByName(string name);
        Task<ICollection<AttractionModel>>GetAttractionByRating(int rating);
        Task<ICollection<AttractionModel>> GetIschildfriendly(bool IsChildFriendly = false);
    }
}