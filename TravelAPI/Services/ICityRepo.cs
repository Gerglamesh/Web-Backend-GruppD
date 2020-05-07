﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public interface ICityRepo
    {
        Task<CityModel> GetCity(string Name);
    }
}
