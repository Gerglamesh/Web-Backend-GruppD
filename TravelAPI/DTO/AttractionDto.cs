using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class AttractionDto
    {
        [Required] public int AttractionId { get; set; }
        [Required] public string Name { get; set; }        
        public string Location { get; set; }        
        public bool IsChildFriendly { get; set; }        
        public string Information { get; set; }       
        public int Rating { get; set; }

        //Relationships
        public CityDto City { get; set; }
    }
}
