using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IAttractionRepo : IRepository
    {
        Task<ICollection<AttractionModel>> GetAttractions(bool includeCities = false);
        Task<AttractionModel>GetAttraction(string name);
        Task<ICollection<AttractionModel>>GetRating(int rating);
        Task<ICollection<AttractionModel>> GetIschildfriendly (bool isChildFriendly);
    }
}