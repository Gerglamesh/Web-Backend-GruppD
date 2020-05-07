using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    interface ICountryRepo
    {
            Task<CountryModel> GetCity(string name);
<<<<<<< HEAD
=======
            Task<CountryModel> GetCity(int id);
>>>>>>> TRAPI-67
    }
}
