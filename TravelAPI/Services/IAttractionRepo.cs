using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface IAttractionRepo
    {

        Task<AttractionModel>GetAttraction(string name);
        Task<ICollection<AttractionModel>> GetIschildfriendly (bool IsChildFriendly);

    }
}
