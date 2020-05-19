using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class CountryDto
    {
        [Required] public int CountryId { get; set; }
        [Required] public string Name { get; set; }

        //Relationships
        public CountryInfoDto CountryInfo { get; set; }
        public ICollection<CityDto> Cities { get; set; }
        public TravelRestrictionDto TravelRestriction { get; set; }
    }
}
