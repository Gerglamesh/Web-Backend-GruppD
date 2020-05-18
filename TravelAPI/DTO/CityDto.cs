using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class CityDto
    {
        [Required] public int CityId { get; set; }
        [Required] public string Name { get; set; }
        public int Population { get; set; }

        public CountryDto Country { get; set; }
        public ICollection<AttractionDto> Attractions { get; set; }
    }
}
