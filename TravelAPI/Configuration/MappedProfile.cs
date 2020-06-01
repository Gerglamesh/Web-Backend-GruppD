using AutoMapper;
using TravelAPI.DTO;
using TravelAPI.Models;

namespace TravelAPI.Services
{
    public class MappedProfile : Profile
    {
        public MappedProfile()
        {
            CreateMap<AttractionModel, AttractionDto>()
                .ReverseMap();
                
            CreateMap<CityModel, CityDto>()
                .ForMember(x => x.Attractions, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<CountryModel, CountryDto>()
                .ReverseMap();

            CreateMap<CountryInfoModel, CountryInfoDto>()
                .ReverseMap();

            CreateMap<TravelRestrictionModel, TravelRestrictionDto>()
                .ReverseMap();
        }
    }
}