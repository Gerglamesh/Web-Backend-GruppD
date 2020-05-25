using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class CityDto
    {
        [Required] 
        public int CityId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,85}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Name { get; set; }
        [Range(1, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}")] 
        public int Population { get; set; }
        [Required]
        public CountryDto Country { get; set; }
        public ICollection<AttractionDto> Attractions { get; set; }
    }
}
