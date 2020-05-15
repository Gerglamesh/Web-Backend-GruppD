using AutoMapper;
using TravelAPI.DTO;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class MappedProfile : Profile
    {
        public MappedProfile()
        {
            
            CreateMap<CityModel, CityDto>()
                .ReverseMap();

  
        }

    }
}