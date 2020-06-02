using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelAPI.Hateoas;

namespace TravelAPI.DTO
{
    public class CountryDto
    {
        [Required] 
        public int CountryId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,56}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Name { get; set; }

        //Relationships
        public CountryInfoDto CountryInfo { get; set; }
        public ICollection<CityDto> Cities { get; set; }
        public TravelRestrictionDto TravelRestriction { get; set; }
        public IEnumerable<Link> Attractions { get; set; } = null;
        public IEnumerable<Link> Links { get; set; }

        public void Add(IEnumerable<Link> links, IEnumerable<Link> attractionLinks = null)
        {
            Links = links;
            Attractions = attractionLinks;
        }
    }
}
