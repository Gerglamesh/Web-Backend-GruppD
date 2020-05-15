using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelAPI.Models;

namespace TravelAPI.DTO
{
    public class CountryDto
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }

        //Relationships
        public CountryInfoModel CountryInfo { get; set; }
        public ICollection<CityModel> Cities { get; set; }
        public TravelRestrictionModel TravelRestriction { get; set; }
    }
}
