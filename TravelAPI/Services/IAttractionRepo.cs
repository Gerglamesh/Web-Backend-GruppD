using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IAttractionRepo : IRepository
    {
        Task<AttractionModel>GetAttraction(string name);
        Task<ICollection<AttractionModel>>GetRating(int rating);
        Task<ICollection<AttractionModel>> GetIschildfriendly (bool isChildFriendly);
    }
}