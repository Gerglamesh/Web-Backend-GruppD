using System.ComponentModel.DataAnnotations;

namespace TravelAPI.DTO
{
    public class TravelRestrictionDto
    {
        [Required] 
        public int TravelRestrictionId { get; set; }
        [Required] 
        public bool IsWorkTravelAllowed { get; set; }
        [Required] 
        public bool IsTourismAllowed { get; set; }
        [Required] 
        public bool IsImmigrationAllowed { get; set; }
        [Required] 
        public bool IsCitizenshipAllowed { get; set; }
        [Required] 
        public bool IsFamilyVisitAllowed { get; set; }
        [Required] 
        public bool IsVisaNeeded { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int RiskLevel { get; set; }
    }
}
