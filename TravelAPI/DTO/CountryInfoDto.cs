using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class CountryInfoDto
    {
        [Required] 
        public int CountryInfoId { get; set; }
        [Required]
        [Range(1, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Population { get; set; } 
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Governance { get; set; }
        [Required]
        [Range(1, 9223372036854775807, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int BNP { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,85}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string CapitalCity { get; set; }
        [Required]
        [Range(1, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Area { get; set; }
        [Required] 
        public string TimeZone { get; set; }
        [Required]
        public string NationalDay { get; set; }
        [Required] 
        public bool RightHandTraffic { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$",
            ErrorMessage = "Characters are not allowed or text is to long/short.")]
        public string Language { get; set; }
    }
}