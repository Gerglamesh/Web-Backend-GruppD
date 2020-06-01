using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using TravelAPI.Hateoas;

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
        public CountryDto Country { get; set; }
        public IEnumerable<Link> Attractions { get; set; } = null;
        public IEnumerable<Link> Links { get; set; }

        public void Add(IEnumerable<Link> links, IEnumerable<Link> attractionLinks = null)
        {
            Links = links;
            Attractions = attractionLinks;
        }
    }
}
