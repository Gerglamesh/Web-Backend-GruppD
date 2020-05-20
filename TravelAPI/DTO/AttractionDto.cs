using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class AttractionDto
    {
        [Required]
        public int AttractionId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,85}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Location { get; set; }        
        public bool IsChildFriendly { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$", 
            ErrorMessage = "Characters are not allowed.")]
        public string Information { get; set; }
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Rating { get; set; }

        //Relationships
        public CityDto City { get; set; }
    }
}
